using System;
using System.Collections;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace clientComCsharp
{
 
    public partial class frmClientCOM : Form
    {
        public static bool MCTABUFF_Enabled = true;
        public static MCTABUFFLib.MCTABUFF_buffer MCTABuff; //so called client com object
        static int ms0;
        static bool executed;
        static string sEvent;
        public const string PHONE_RINGING = "Phone ringing";
        public const string PHONE_CONNECTED = "Phone connected";
        public const string PHONE_DISCONNECTED = "Phone disconnected";
        public Dictionary<string, phoneCall> callsDict; //dictionary for keeping ongoing calls found by callid
        public String imgpath = "img/"; //expecting img directory to to be found from the executable path
        public Boolean holdState = false;
       
        
        public frmClientCOM()
        {
            InitializeComponent();
            timer1.Start();
           
        }

        public void ShowStatus(string Text)
        {
            if (this.checkBox1.CheckState == CheckState.Checked)
            {
                while (this.lstStatus.Items.Count > 1000) //no more than 1000 rows
                {
                this.lstStatus.Items.RemoveAt(0);
                }

                this.lstStatus.Items.Add(Text);
                this.lstStatus.SelectedIndex = this.lstStatus.Items.Count - 1;
  
            }
        }

        //agent states
        public sealed class EvtAgent
        {
            private EvtAgent() { }
            public const string Paperwork  = "StatusPaperWork";
            public const string Working  = "StatusWorking";
            public const string Paused = "StatusPause";
        }

        //call states
        public sealed class EvtCall
        {
            private EvtCall() { }

            public const string Coming   = "AddQueueCall";
            public const string Generic   = "Generic";
            public const string CallOut    = "OperCallOut";
            public const string QueStats    = "QueStats";
            public const string Connected    = "AddConnectedCall";
            public const string Disconnected  = "Disconnected";
            public const string SetActiveCall  = "SetActiveCall";
            public const string ClearActiveCall = "ClearActiveCall";
            public const string CallOutAlerting  = "OperCallOutAlerting";
        }

        public sealed class EvtChat
        {
            private EvtChat() { }
            public const string Changed = "chatChanged";
            public const string Reroute = "reroute";
        }

         public void InitMCTABuff()
        {
            int Diff = 0;
            int Ms = 0;

            if (MCTABuff == null)
            {
                ServerNotRunning();
                if (MCTABUFF_Enabled)
                {
                    Ms = Environment.TickCount;
                    Diff = Ms - ms0;
                    if (Diff < 0)
                    {
                        ms0 = Ms;
                        Diff = 0;
                    }
                    ShowStatus("Waited " + Diff.ToString() + " ms");
                    if (Diff > 2000)
                    {
                        ms0 = Ms;
                        ShowStatus("Creating MCTABUFF.MCTABUFF_buffer...");
                        MCTABuff = new MCTABUFFLib.MCTABUFF_buffer();
                        if (MCTABuff == null)
                        {
                            ShowStatus("Can't create MCTABUFF.MCTABUFF_buffer");
                            if (!executed)
                            {
                                MessageBox.Show("Can't create MCTABUFF.MCTABUFF_buffer",
                                                "Important Note",
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Exclamation,
                                                 MessageBoxDefaultButton.Button1);

                                executed = true;
                            }
                        }
                        else
                        {
                            ShowStatus("MCTABuff.Initialize");
                            string sType = "CLIENT";
                            string Name = "CSharpTestClient";
                            string Server = "SwitchBoard";
                            //bind client to listen the server
                            MCTABuff.Initialize("TYPE=" + sType + ";NAME=" + Name + ";SERVER=" + Server + ";");
                        }
                    }
                }
            }
            else if (!MCTABUFF_Enabled)
            {
                ShowStatus("Destroying MCTABuff");
                ServerNotRunning();
                MCTABuff.Destroy();
                MCTABuff = null;
            }
        }


        public object ProcessMCTABuff()
        {
            object functionReturnValue = null;
            functionReturnValue = false;
 
            InitMCTABuff();
            string EVT = null;
            System.Collections.Generic.Dictionary<string, string> mctabuff_msg = null;
            string CMD = null;
            if (MCTABuff != null)
            {
                 if (string.IsNullOrEmpty(sEvent))
                {
                    EVT = "";
                    sEvent = "";
                    EVT = (string)MCTABuff.GetEventRet("_WAIT=0;");//using event read that returs immediately
                    if (!string.IsNullOrEmpty(EVT))
                    {
                        sEvent = EVT;
                    }

                    if (sEvent.Length != 0)
                    {
                        ShowStatus(UrlDecode(sEvent));
                        //creating dictionary object for msg handling
                        mctabuff_msg = new System.Collections.Generic.Dictionary<string, string>();
                        //parse event to dict
                        UrlParse(mctabuff_msg, sEvent);
                        EVT = UrlGet(mctabuff_msg, "_EVT");
                        switch (EVT)
                        {
                            case "SERVER_ADDED":
                                ServerIsRunning();
                                getOperatorStatus();
                                break;
                            case "SERVER_REMOVED":
                                ServerNotRunning();
                                break;
                            case "OPERATOR_STATUS":
                                string sta = UrlGet(mctabuff_msg, "Status");
                                setOperatorStatus(sta);
                                break;
                            case EvtChat.Changed: //chat changed
                                Console.WriteLine("chatChanged");
                                var AD = UrlGet(mctabuff_msg, "ATTACHED_DATA");
                                var statu = UrlGet(mctabuff_msg, "STATUS");
                                Console.WriteLine(statu);
                                break;
                            case EvtChat.Reroute: //reroute
                                Console.WriteLine("Reroute");
                                break;
                            default:
                                CMD = UrlGet(mctabuff_msg, "_CMD");
                                switch (CMD)
                                {
                                    case EvtCall.CallOut:
                                        callOut(mctabuff_msg);
                                        break;
                                    case EvtCall.CallOutAlerting:
                                        callOutAlerting(mctabuff_msg);
                                        break;
                                    case EvtCall.Coming:
                                        phoneRinging(mctabuff_msg);
                                        break;
                                    case EvtCall.Connected:
                                        callConnected(mctabuff_msg);
                                        break;
                                    case EvtCall.Disconnected:
                                        callDisconnected(mctabuff_msg);
                                        break;
                                    case EvtCall.SetActiveCall:
                                        setCallStatus(mctabuff_msg, "release");
                                        break;
                                    case EvtCall.ClearActiveCall:
                                        setCallStatus(mctabuff_msg, "held");
                                        break;
                                    case EvtCall.QueStats:
                                        //usually useles to check Queue status events
                                        //now "missusing" event as timer to do periodic check against agent status
                                        
                                        getOperatorStatus();
                                        break;
                                    case EvtCall.Generic:
                                        //could be used for capturing e.g. recoding data
                                        break;
                                }
                                break;
                        }
                        mctabuff_msg = null;
                        sEvent = "";
                    }
                    functionReturnValue = true;
                }
            }
            return functionReturnValue;
        }

        private static string UrlDecode(string tmp)
        {
            return System.Uri.UnescapeDataString(tmp);
        }

        public static string UrlEncode(string tmp)
        {
            return System.Uri.EscapeUriString(tmp);
            
        }

        public void setOperatorStatus(string sta) {
            switch (sta)
            {
                case EvtAgent.Working:
                    radioBtnServing.Checked = true;
                    break;
                case EvtAgent.Paused:
                    radioBtnPaused.Checked = true;
                    break;
                case EvtAgent.Paperwork:
                    radioBtnPaperwork.Checked = true;
                    break;
            }
        }

        public void phoneRinging(System.Collections.Generic.Dictionary<string, string> mctabuff_msg)
        {
            string cg = mctabuff_msg["CALL_ID"];
            string ani = UrlGet(mctabuff_msg, "ANumber");
            string bni = UrlGet(mctabuff_msg, "BNumber");
            string cad = UrlGet(mctabuff_msg, "ExtraData");
            string rmi = UrlGet(mctabuff_msg, "REMOTE_INFO"); //remote info containing caller names
            
            Console.WriteLine("RMI in alerting phase: " + rmi);
            //ani = (rmi, "EN");
            //crete new phoneCall object
            phoneCall pcall = new phoneCall(cg, ani, bni, ani, cad, "InComing");
            //add call to dict to hold the ongoing calls
            callsDict.Add(pcall.callId, pcall);
            //add call also ToListView; display caller number; expecting an incoming call image to be in postion 0
            ListViewItem call = new ListViewItem(pcall.CallerNumber, 0);
            call.Tag = pcall.callId;
            listCalls.Items.Add(call);
            if (listCalls.Items.Count == 1)
            {
                listCalls.Items[0].Focused = true;
                listCalls.Items[0].Selected = true;
            }
                
            handleCallAttachedData(cad);
            this.toolStripStatusLabel2.Text = "Ringing";
            
            //later update remote info on top of ani
            handleRemoteInfo(getRemoteInfo("EN", rmi), pcall.callId);
  
        }

        public void callOut(System.Collections.Generic.Dictionary<string, string> mctabuff_msg)
        {
            string cg = mctabuff_msg["CALL_ID"];
            string bni = UrlGet(mctabuff_msg, "BNumber");
            string cad = UrlGet(mctabuff_msg, "ExtraData");

            //create new phoneCall object
            phoneCall pcall = new phoneCall(cg, "Me", bni, bni, cad, "OutGoing");
            //add call to dict of ongoing calls
            callsDict.Add(pcall.callId, pcall);
            //add call ToListView; show calledNumber; expecting call out image to be in postion 1
            ListViewItem call = new ListViewItem(pcall.CalledNumber, 1);
            call.Tag = pcall.callId;
            listCalls.Items.Add(call);
            if (listCalls.Items.Count == 1)
            {
                listCalls.Items[0].Focused = true;
                listCalls.Items[0].Selected = true;
            }
            this.toolStripStatusLabel2.Text = "Calling..";
        }

        public void callOutAlerting(System.Collections.Generic.Dictionary<string, string> mctabuff_msg)
        {
            string cg = mctabuff_msg["CALL_ID"];
            string rmi = UrlGet(mctabuff_msg, "REMOTE_INFO");
            //later update remote info on top of ani
            handleRemoteInfo(getRemoteInfo("EN", rmi), cg);

            this.toolStripStatusLabel2.Text = "Call Out Alerting..";

        }

        public void callConnected(System.Collections.Generic.Dictionary<string, string> mctabuff_msg) 
        {
            string cg = mctabuff_msg["CALL_ID"];
            callsDict[cg].setState("Connected");
            string rmi = UrlGet(mctabuff_msg, "REMOTE_INFO"); //remote info containing caller names
            
            updateCallList(cg);
            this.toolStripStatusLabel2.Text = "Connected";
            //later update remote info on top of ani
            handleRemoteInfo(getRemoteInfo("EN", rmi), cg);
        }

        public void setCallStatus(System.Collections.Generic.Dictionary<string, string> mctabuff_msg, string sta)
        {
            string cg = mctabuff_msg["CALL_ID"];

            if (sta == "held")
            {
                callsDict[cg].setState("OnHold");
            }else{
                callsDict[cg].setState("Connected");
            }
            updateCallList(cg);
  
        }

        public void getOperatorStatus()
        { 
             Command("_CMD=GET_OPERATOR_STATUS;_SAP_ID=MCTABUFF;");      
        }

        public void callDisconnected(System.Collections.Generic.Dictionary<string, string> mctabuff_msg)
        {
            string cg = mctabuff_msg["CALL_ID"];
            removeCallFromList(cg);
            callsDict.Remove(cg);
            if (callsDict.Keys.Count == 0) { this.toolStripStatusLabel2.Text = "Idle";}
        }

        public void updateCallList(string callid) 
        {
            foreach (ListViewItem i in this.listCalls.Items)
            {
                if (i.Tag.ToString() == callid)
                {
                    i.Text = callsDict[callid].Display;
                    i.ImageIndex = callsDict[callid].currIntState;
                    listCalls.Update();
                }
            }
        }

        public void removeCallFromList(string callid)
        {
            foreach (ListViewItem i in this.listCalls.Items)
            {
                if (i.Tag.ToString() == callid)
                {
                    i.Remove();
                }
            }
        }


        public void handleCallAttachedData(string cad) 
        {
            AttachedDataBox.Clear();
            List<string> sl = cad.Split(';').ToList();

            //just adding some font decorations
            Font regu = new Font("Tahoma", 8, FontStyle.Regular);
            Font bold = new Font("Tahoma", 8, FontStyle.Bold);

            foreach (string l in sl)
            {
                if (l.Length > 1)
                {
                    int selStart = AttachedDataBox.TextLength;
                    AttachedDataBox.SelectionFont = bold;
                    AttachedDataBox.SelectionStart = selStart;
                    AttachedDataBox.AppendText(l.Split('=').First() + ": ");
                    AttachedDataBox.SelectionFont = regu;
                    AttachedDataBox.SelectionColor = Color.Green;
                    AttachedDataBox.SelectionLength = AttachedDataBox.TextLength - selStart;
                    AttachedDataBox.AppendText(l.Split('=').Last().ToString().Replace("%20", " ")  + "\n");
                }
            }
        }

        public String getRemoteInfo(string k, string data){
            //creating dictionary object for msg handling
            System.Collections.Generic.Dictionary<string, string> msg = new System.Collections.Generic.Dictionary<string, string>();
            //parse event to dict
            UrlParse(msg, data);
            string value = null;
            msg.TryGetValue(k, out value);
            return value;
        }
        
        public void handleRemoteInfo(string name, string callid)
        {
            if (!string.IsNullOrEmpty(name))
            {
                    name = System.Uri.UnescapeDataString(name);
                    callsDict[callid].Display = name;
                    updateCall(callid);
           }
        }

        public static void UrlParse(System.Collections.Generic.Dictionary<string, string> mctabuff_msg, string EVT)
        {
            mctabuff_msg.Clear(); //clear the dictionary
            List<string> sl = EVT.Split(';').ToList();

            foreach (string s in sl){
                string skey = s.Split('=').FirstOrDefault();
                string sval = s.Split('=').LastOrDefault();
                mctabuff_msg.Add(skey, sval);
            }

        }

        public static string UrlGet(System.Collections.Generic.Dictionary<string, string> mctabuff_msg, string Key)
        {
            //UrlGet = mctabuff_msg..Item(Key)
            string value = null;
            value = null;
            if (!mctabuff_msg.TryGetValue(Key, out value))
            {
                value = "";
            }
            return UrlDecode(value);
        }

        public void ServerIsRunning()
        {
            Console.WriteLine("Server running");
            statusStrip1.Text = "Server running";
            this.toolStripStatusLabel2.Text = "Server Running";

        }

        public void ServerNotRunning()
        {
            this.toolStripStatusLabel2.Text = "Server not running";
        }

        public void updateCall(string callid)
        {
            foreach (ListViewItem i in this.listCalls.Items)
            {
                if (i.Tag.ToString() == callid)
                {
                    i.Text = callsDict[callid].Display;
                    i.ImageIndex = callsDict[callid].currIntState;
                    listCalls.Update();
                    //listCalls.Refresh();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ProcessMCTABuff();
        }

        public void Command(string CMD) 
        {
            MCTABuff.Command(CMD);
        }

        private void radioBtnServing_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnServing.Checked == true) 
            {
                Command("_CMD=SET_OPERATOR_STATUS;Status=" + EvtAgent.Working.ToString() + ";_SAP_ID=MCTABUFF;");
            }
        }

        private void radioBtnPaperwork_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnPaperwork.Checked == true)
            {
                Command("_CMD=SET_OPERATOR_STATUS;Status=" + EvtAgent.Paperwork.ToString() + ";_SAP_ID=MCTABUFF;");
            }
        }
        private void radioBtnPaused_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnPaused.Checked == true)
            {
                Command("_CMD=SET_OPERATOR_STATUS;Status=" + EvtAgent.Paused.ToString() + ";_SAP_ID=MCTABUFF;");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           //Call out to specified phone number
            Command("_CMD=CALL_OUT;_SAP_ID=MCTABUFF;ADDR=" + UrlEncode(txtPhoneNbr.Text) + ";");
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
           //Answer to incoming call 
            Command("_CMD=ANSWER;_SAP_ID=MCTABUFF;");
        }

        private void btnHup_Click(object sender, EventArgs e)
        {
            //Hang up a call
            Command("_CMD=HANGUP;_SAP_ID=MCTABUFF;");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstStatus.Items.Clear();
        }

        private void frmClientCOM_Load(object sender, EventArgs e)
        {
            callsDict = new Dictionary<string, phoneCall>();
        }

        private void btnHold_Click(object sender, EventArgs e)
        {
            if (holdState == false)
            {
                Command("_CMD=HOLD;_SAP_ID=UI;");
                holdState = true;
            }else{
                Command("_CMD=UNHOLD;_SAP_ID=UI;");
                holdState = false;
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            Command("_CMD=DO_DIVERT;_SAP_ID=MCTABUFF;");
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.lstStatus.SelectedItem.ToString());
        }

    }   
    
    //class for holding phoneCall data and its state
    public class phoneCall
    {
        public string callId;
        private string callerNumber;
        private string calledNumber;
        private string callerName;
        private string attachedData;
        private string display;
        private estate currEnumState;

        private enum estate : int
        {
            InComing = 0,
            OutGoing = 1,
            Connected = 2,
            OnHold = 3,
            Parked = 4,
        }
  
     public phoneCall(string cId, string callernum, string callednum, string disp, string extdata, string startstate)
        {
            callId = cId;

            callerNumber = callernum;
            calledNumber = callednum;
            display = disp;
            attachedData = extdata;
            currEnumState = (estate)Enum.Parse(typeof(estate), startstate);
        }

        public void setState(string newstate)
        {
            currEnumState = (estate)Enum.Parse(typeof(estate), newstate);
        }

        public string Display
        {
            set { display = value; }
            get { return display; }
        }

        public string CallerNumber
        {
            get { return callerNumber; }
        }

        public string CallerName
        {
            get { return callerName; }
            set { callerName = value; }
        }

        public string CalledNumber
        {
            get { return calledNumber; }
        }

        public string AttachedData
        {
            get { return attachedData; }
        }

        public string currStrState
        {
            get { return currEnumState.ToString(); }
        }

        public int currIntState
        {
            get { return (int)currEnumState; }
        }
    }
}
