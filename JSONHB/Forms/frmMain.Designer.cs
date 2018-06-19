namespace JSONHB
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.grpParams = new System.Windows.Forms.GroupBox();
            this.cmbHeartbeatURL = new System.Windows.Forms.ComboBox();
            this.btnRoute = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnFileOpen1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUAV_SN = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSecretKey = new System.Windows.Forms.TextBox();
            this.grpTrackbar = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkPause = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.txtMsgText = new System.Windows.Forms.TextBox();
            this.btnWebForm = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnPropertiesSave = new System.Windows.Forms.Button();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.radTCP = new System.Windows.Forms.RadioButton();
            this.radUDP = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.grpParams.SuspendLayout();
            this.grpTrackbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpParams
            // 
            this.grpParams.Controls.Add(this.label1);
            this.grpParams.Controls.Add(this.radUDP);
            this.grpParams.Controls.Add(this.radTCP);
            this.grpParams.Controls.Add(this.cmbHeartbeatURL);
            this.grpParams.Controls.Add(this.btnRoute);
            this.grpParams.Controls.Add(this.btnSave);
            this.grpParams.Controls.Add(this.txtFileName);
            this.grpParams.Controls.Add(this.btnFileOpen1);
            this.grpParams.Controls.Add(this.label5);
            this.grpParams.Controls.Add(this.label6);
            this.grpParams.Controls.Add(this.txtUAV_SN);
            this.grpParams.Controls.Add(this.label7);
            this.grpParams.Controls.Add(this.txtSecretKey);
            this.grpParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpParams.Location = new System.Drawing.Point(22, 26);
            this.grpParams.Name = "grpParams";
            this.grpParams.Size = new System.Drawing.Size(854, 214);
            this.grpParams.TabIndex = 21;
            this.grpParams.TabStop = false;
            this.grpParams.Text = "Heartbeat Parameters";
            // 
            // cmbHeartbeatURL
            // 
            this.cmbHeartbeatURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHeartbeatURL.FormattingEnabled = true;
            this.cmbHeartbeatURL.Location = new System.Drawing.Point(125, 145);
            this.cmbHeartbeatURL.Name = "cmbHeartbeatURL";
            this.cmbHeartbeatURL.Size = new System.Drawing.Size(575, 28);
            this.cmbHeartbeatURL.TabIndex = 24;
            this.cmbHeartbeatURL.SelectedIndexChanged += new System.EventHandler(this.cmbHeartbeatURL_SelectedIndexChanged);
            // 
            // btnRoute
            // 
            this.btnRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoute.Location = new System.Drawing.Point(761, 47);
            this.btnRoute.Name = "btnRoute";
            this.btnRoute.Size = new System.Drawing.Size(75, 35);
            this.btnRoute.TabIndex = 21;
            this.btnRoute.Text = "Route";
            this.btnRoute.UseVisualStyleBackColor = true;
            this.btnRoute.Visible = false;
            this.btnRoute.Click += new System.EventHandler(this.btnRoute_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(755, 141);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 35);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Location = new System.Drawing.Point(125, 45);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(626, 26);
            this.txtFileName.TabIndex = 4;
            // 
            // btnFileOpen1
            // 
            this.btnFileOpen1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileOpen1.Location = new System.Drawing.Point(9, 37);
            this.btnFileOpen1.Name = "btnFileOpen1";
            this.btnFileOpen1.Size = new System.Drawing.Size(104, 34);
            this.btnFileOpen1.TabIndex = 0;
            this.btnFileOpen1.Text = "Route File";
            this.btnFileOpen1.UseVisualStyleBackColor = true;
            this.btnFileOpen1.Click += new System.EventHandler(this.btnFileOpen1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "End Point:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(48, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "UAV SN:";
            // 
            // txtUAV_SN
            // 
            this.txtUAV_SN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUAV_SN.Location = new System.Drawing.Point(125, 79);
            this.txtUAV_SN.Name = "txtUAV_SN";
            this.txtUAV_SN.ReadOnly = true;
            this.txtUAV_SN.Size = new System.Drawing.Size(173, 26);
            this.txtUAV_SN.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Secret Key:";
            // 
            // txtSecretKey
            // 
            this.txtSecretKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecretKey.Location = new System.Drawing.Point(125, 111);
            this.txtSecretKey.Name = "txtSecretKey";
            this.txtSecretKey.ReadOnly = true;
            this.txtSecretKey.Size = new System.Drawing.Size(575, 26);
            this.txtSecretKey.TabIndex = 12;
            // 
            // grpTrackbar
            // 
            this.grpTrackbar.Controls.Add(this.label8);
            this.grpTrackbar.Controls.Add(this.chkPause);
            this.grpTrackbar.Controls.Add(this.trackBar1);
            this.grpTrackbar.Location = new System.Drawing.Point(22, 251);
            this.grpTrackbar.Name = "grpTrackbar";
            this.grpTrackbar.Size = new System.Drawing.Size(854, 100);
            this.grpTrackbar.TabIndex = 24;
            this.grpTrackbar.TabStop = false;
            this.grpTrackbar.Text = "Simulation Speed (1X)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(24, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "..";
            this.label8.Visible = false;
            // 
            // chkPause
            // 
            this.chkPause.AutoSize = true;
            this.chkPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPause.Location = new System.Drawing.Point(755, 25);
            this.chkPause.Name = "chkPause";
            this.chkPause.Size = new System.Drawing.Size(77, 24);
            this.chkPause.TabIndex = 22;
            this.chkPause.Text = "Hover";
            this.chkPause.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.BackColor = System.Drawing.Color.White;
            this.trackBar1.LargeChange = 500;
            this.trackBar1.Location = new System.Drawing.Point(46, 35);
            this.trackBar1.Maximum = 10000;
            this.trackBar1.Minimum = 500;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(694, 48);
            this.trackBar1.SmallChange = 100;
            this.trackBar1.TabIndex = 19;
            this.trackBar1.TickFrequency = 500;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Value = 500;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtResponse);
            this.groupBox2.Controls.Add(this.txtMsgText);
            this.groupBox2.Location = new System.Drawing.Point(22, 360);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(853, 344);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Request / Response";
            // 
            // txtResponse
            // 
            this.txtResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResponse.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtResponse.Location = new System.Drawing.Point(27, 180);
            this.txtResponse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResponse.Size = new System.Drawing.Size(793, 154);
            this.txtResponse.TabIndex = 8;
            // 
            // txtMsgText
            // 
            this.txtMsgText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsgText.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtMsgText.Location = new System.Drawing.Point(27, 35);
            this.txtMsgText.Multiline = true;
            this.txtMsgText.Name = "txtMsgText";
            this.txtMsgText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsgText.Size = new System.Drawing.Size(793, 137);
            this.txtMsgText.TabIndex = 15;
            // 
            // btnWebForm
            // 
            this.btnWebForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWebForm.Location = new System.Drawing.Point(52, 720);
            this.btnWebForm.Name = "btnWebForm";
            this.btnWebForm.Size = new System.Drawing.Size(75, 36);
            this.btnWebForm.TabIndex = 27;
            this.btnWebForm.Text = "JSON";
            this.btnWebForm.UseVisualStyleBackColor = true;
            this.btnWebForm.Click += new System.EventHandler(this.btnWebForm_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(783, 720);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 36);
            this.btnStart.TabIndex = 28;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(920, 804);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 29;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpParams);
            this.tabPage1.Controls.Add(this.btnStart);
            this.tabPage1.Controls.Add(this.grpTrackbar);
            this.tabPage1.Controls.Add(this.btnWebForm);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(912, 771);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Heartbeat";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnPropertiesSave);
            this.tabPage2.Controls.Add(this.propertyGrid1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(912, 748);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnPropertiesSave
            // 
            this.btnPropertiesSave.Location = new System.Drawing.Point(809, 687);
            this.btnPropertiesSave.Name = "btnPropertiesSave";
            this.btnPropertiesSave.Size = new System.Drawing.Size(87, 43);
            this.btnPropertiesSave.TabIndex = 1;
            this.btnPropertiesSave.Text = "Save";
            this.btnPropertiesSave.UseVisualStyleBackColor = true;
            this.btnPropertiesSave.Click += new System.EventHandler(this.btnPropertiesSave_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(6, 6);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(900, 642);
            this.propertyGrid1.TabIndex = 0;
            // 
            // radTCP
            // 
            this.radTCP.AutoSize = true;
            this.radTCP.Checked = true;
            this.radTCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTCP.Location = new System.Drawing.Point(127, 179);
            this.radTCP.Name = "radTCP";
            this.radTCP.Size = new System.Drawing.Size(64, 24);
            this.radTCP.TabIndex = 25;
            this.radTCP.TabStop = true;
            this.radTCP.Text = "TCP";
            this.radTCP.UseVisualStyleBackColor = true;
            // 
            // radUDP
            // 
            this.radUDP.AutoSize = true;
            this.radUDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radUDP.Location = new System.Drawing.Point(197, 179);
            this.radUDP.Name = "radUDP";
            this.radUDP.Size = new System.Drawing.Size(68, 24);
            this.radUDP.TabIndex = 26;
            this.radUDP.Text = "UDP";
            this.radUDP.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Protocol:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(953, 828);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grpParams.ResumeLayout(false);
            this.grpParams.PerformLayout();
            this.grpTrackbar.ResumeLayout(false);
            this.grpTrackbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpParams;
        private System.Windows.Forms.Button btnRoute;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnFileOpen1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUAV_SN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSecretKey;
        private System.Windows.Forms.GroupBox grpTrackbar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkPause;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.TextBox txtMsgText;
        private System.Windows.Forms.Button btnWebForm;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cmbHeartbeatURL;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button btnPropertiesSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radUDP;
        private System.Windows.Forms.RadioButton radTCP;
    }
}

