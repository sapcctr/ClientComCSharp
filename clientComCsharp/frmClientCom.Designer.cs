namespace clientComCsharp
{
    partial class frmClientCOM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientCOM));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listCalls = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnHold = new System.Windows.Forms.Button();
            this.btnHup = new System.Windows.Forms.Button();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.btnCallOut = new System.Windows.Forms.Button();
            this.AttachedDataBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioBtnPaused = new System.Windows.Forms.RadioButton();
            this.radioBtnPaperwork = new System.Windows.Forms.RadioButton();
            this.radioBtnServing = new System.Windows.Forms.RadioButton();
            this.txtPhoneNbr = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnClear = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lstStatus = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(671, 276);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listCalls);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnTransfer);
            this.tabPage1.Controls.Add(this.btnHold);
            this.tabPage1.Controls.Add(this.btnHup);
            this.tabPage1.Controls.Add(this.btnAnswer);
            this.tabPage1.Controls.Add(this.btnCallOut);
            this.tabPage1.Controls.Add(this.AttachedDataBox);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.txtPhoneNbr);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(663, 250);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Controls";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listCalls
            // 
            this.listCalls.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listCalls.FullRowSelect = true;
            this.listCalls.HideSelection = false;
            this.listCalls.Location = new System.Drawing.Point(6, 80);
            this.listCalls.Name = "listCalls";
            this.listCalls.Size = new System.Drawing.Size(330, 38);
            this.listCalls.SmallImageList = this.imgList;
            this.listCalls.TabIndex = 10;
            this.listCalls.UseCompatibleStateImageBehavior = false;
            this.listCalls.View = System.Windows.Forms.View.List;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 150;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "Phone_incoming_call.gif");
            this.imgList.Images.SetKeyName(1, "Phone_outgoing_call.gif");
            this.imgList.Images.SetKeyName(2, "Phone_connected.gif");
            this.imgList.Images.SetKeyName(3, "Phone_hold.gif");
            this.imgList.Images.SetKeyName(4, "Phone_parked.gif");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(342, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Attached data display";
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(258, 124);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(78, 24);
            this.btnTransfer.TabIndex = 8;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // btnHold
            // 
            this.btnHold.Location = new System.Drawing.Point(174, 124);
            this.btnHold.Name = "btnHold";
            this.btnHold.Size = new System.Drawing.Size(78, 24);
            this.btnHold.TabIndex = 6;
            this.btnHold.Text = "hold/unhold";
            this.btnHold.UseVisualStyleBackColor = true;
            this.btnHold.Click += new System.EventHandler(this.btnHold_Click);
            // 
            // btnHup
            // 
            this.btnHup.Location = new System.Drawing.Point(90, 124);
            this.btnHup.Name = "btnHup";
            this.btnHup.Size = new System.Drawing.Size(78, 24);
            this.btnHup.TabIndex = 5;
            this.btnHup.Text = "HangUp";
            this.btnHup.UseVisualStyleBackColor = true;
            this.btnHup.Click += new System.EventHandler(this.btnHup_Click);
            // 
            // btnAnswer
            // 
            this.btnAnswer.Location = new System.Drawing.Point(6, 124);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(78, 24);
            this.btnAnswer.TabIndex = 4;
            this.btnAnswer.Text = "Answer";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // btnCallOut
            // 
            this.btnCallOut.Location = new System.Drawing.Point(258, 154);
            this.btnCallOut.Name = "btnCallOut";
            this.btnCallOut.Size = new System.Drawing.Size(78, 24);
            this.btnCallOut.TabIndex = 3;
            this.btnCallOut.Text = "Call";
            this.btnCallOut.UseVisualStyleBackColor = true;
            this.btnCallOut.Click += new System.EventHandler(this.button1_Click);
            // 
            // AttachedDataBox
            // 
            this.AttachedDataBox.Location = new System.Drawing.Point(342, 33);
            this.AttachedDataBox.Name = "AttachedDataBox";
            this.AttachedDataBox.Size = new System.Drawing.Size(315, 207);
            this.AttachedDataBox.TabIndex = 2;
            this.AttachedDataBox.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioBtnPaused);
            this.groupBox1.Controls.Add(this.radioBtnPaperwork);
            this.groupBox1.Controls.Add(this.radioBtnServing);
            this.groupBox1.Location = new System.Drawing.Point(6, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 56);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agent State";
            // 
            // radioBtnPaused
            // 
            this.radioBtnPaused.AutoSize = true;
            this.radioBtnPaused.Location = new System.Drawing.Point(219, 19);
            this.radioBtnPaused.Name = "radioBtnPaused";
            this.radioBtnPaused.Size = new System.Drawing.Size(61, 17);
            this.radioBtnPaused.TabIndex = 2;
            this.radioBtnPaused.TabStop = true;
            this.radioBtnPaused.Text = "Paused";
            this.radioBtnPaused.UseVisualStyleBackColor = true;
            this.radioBtnPaused.CheckedChanged += new System.EventHandler(this.radioBtnPaused_CheckedChanged);
            // 
            // radioBtnPaperwork
            // 
            this.radioBtnPaperwork.AutoSize = true;
            this.radioBtnPaperwork.Location = new System.Drawing.Point(123, 19);
            this.radioBtnPaperwork.Name = "radioBtnPaperwork";
            this.radioBtnPaperwork.Size = new System.Drawing.Size(76, 17);
            this.radioBtnPaperwork.TabIndex = 1;
            this.radioBtnPaperwork.TabStop = true;
            this.radioBtnPaperwork.Text = "Paperwork";
            this.radioBtnPaperwork.UseVisualStyleBackColor = true;
            this.radioBtnPaperwork.CheckedChanged += new System.EventHandler(this.radioBtnPaperwork_CheckedChanged);
            // 
            // radioBtnServing
            // 
            this.radioBtnServing.AutoSize = true;
            this.radioBtnServing.Location = new System.Drawing.Point(38, 19);
            this.radioBtnServing.Name = "radioBtnServing";
            this.radioBtnServing.Size = new System.Drawing.Size(61, 17);
            this.radioBtnServing.TabIndex = 0;
            this.radioBtnServing.TabStop = true;
            this.radioBtnServing.Text = "Serving";
            this.radioBtnServing.UseVisualStyleBackColor = true;
            this.radioBtnServing.CheckedChanged += new System.EventHandler(this.radioBtnServing_CheckedChanged);
            // 
            // txtPhoneNbr
            // 
            this.txtPhoneNbr.Location = new System.Drawing.Point(6, 154);
            this.txtPhoneNbr.Name = "txtPhoneNbr";
            this.txtPhoneNbr.Size = new System.Drawing.Size(246, 20);
            this.txtPhoneNbr.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnClear);
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Controls.Add(this.lstStatus);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(663, 250);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Debug";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(581, 34);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(580, 10);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(56, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "debug";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lstStatus
            // 
            this.lstStatus.ContextMenuStrip = this.contextMenuStrip1;
            this.lstStatus.FormattingEnabled = true;
            this.lstStatus.Location = new System.Drawing.Point(7, 10);
            this.lstStatus.Name = "lstStatus";
            this.lstStatus.Size = new System.Drawing.Size(567, 225);
            this.lstStatus.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(145, 26);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 306);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(696, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // frmClientCOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 328);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmClientCOM";
            this.Text = "phone C&C";
            this.Load += new System.EventHandler(this.frmClientCOM_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox lstStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.RichTextBox AttachedDataBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBtnPaused;
        private System.Windows.Forms.RadioButton radioBtnPaperwork;
        private System.Windows.Forms.RadioButton radioBtnServing;
        private System.Windows.Forms.TextBox txtPhoneNbr;
        private System.Windows.Forms.Button btnHold;
        private System.Windows.Forms.Button btnHup;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.Button btnCallOut;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListView listCalls;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}

