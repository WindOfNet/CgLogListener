namespace CgLogListener
{
    partial class FormMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMinsize = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolExit = new System.Windows.Forms.ToolStripMenuItem();
            this.txtCgLogPath = new System.Windows.Forms.TextBox();
            this.btnSelectLogPath = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cgLogListenerTrackBar = new CgLogListener.CgLogListenerTrackBar();
            this.cgLogListenerSettingCheckBox1 = new CgLogListener.CgLogListenerCheckBox();
            this.cgLogListenerCheckBox6 = new CgLogListener.CgLogListenerCheckBox();
            this.cgLogListenerCheckBox5 = new CgLogListener.CgLogListenerCheckBox();
            this.cgLogListenerCheckBox4 = new CgLogListener.CgLogListenerCheckBox();
            this.cgLogListenerCheckBox3 = new CgLogListener.CgLogListenerCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cgLogListenerListBox = new CgLogListener.CgLogListenerListBox();
            this.btnDelCus = new System.Windows.Forms.Button();
            this.btnAddCus = new System.Windows.Forms.Button();
            this.cgLogListenerCheckBox2 = new CgLogListener.CgLogListenerCheckBox();
            this.cgLogListenerCheckBox1 = new CgLogListener.CgLogListenerCheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.notifyIconContextMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cgLogListenerTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipTitle = "魔力Log監視";
            this.notifyIcon.ContextMenuStrip = this.notifyIconContextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "魔力Log監視";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.NotifyIcon_DoubleClick);
            // 
            // notifyIconContextMenu
            // 
            this.notifyIconContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.notifyIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOpen,
            this.toolMinsize,
            this.toolSep1,
            this.toolExit});
            this.notifyIconContextMenu.Name = "notifyIconContextMenu";
            this.notifyIconContextMenu.ShowImageMargin = false;
            this.notifyIconContextMenu.Size = new System.Drawing.Size(86, 76);
            // 
            // toolOpen
            // 
            this.toolOpen.Name = "toolOpen";
            this.toolOpen.Size = new System.Drawing.Size(85, 22);
            this.toolOpen.Text = "開啟";
            this.toolOpen.Click += new System.EventHandler(this.ToolOpen_Click);
            // 
            // toolMinsize
            // 
            this.toolMinsize.Name = "toolMinsize";
            this.toolMinsize.Size = new System.Drawing.Size(85, 22);
            this.toolMinsize.Text = "最小化";
            this.toolMinsize.Click += new System.EventHandler(this.ToolMinsize_Click);
            // 
            // toolSep1
            // 
            this.toolSep1.Name = "toolSep1";
            this.toolSep1.Size = new System.Drawing.Size(82, 6);
            // 
            // toolExit
            // 
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(85, 22);
            this.toolExit.Text = "結束";
            this.toolExit.Click += new System.EventHandler(this.ToolExit_Click);
            // 
            // txtCgLogPath
            // 
            this.txtCgLogPath.Location = new System.Drawing.Point(11, 9);
            this.txtCgLogPath.Margin = new System.Windows.Forms.Padding(2);
            this.txtCgLogPath.Name = "txtCgLogPath";
            this.txtCgLogPath.ReadOnly = true;
            this.txtCgLogPath.Size = new System.Drawing.Size(219, 22);
            this.txtCgLogPath.TabIndex = 1;
            // 
            // btnSelectLogPath
            // 
            this.btnSelectLogPath.Location = new System.Drawing.Point(234, 8);
            this.btnSelectLogPath.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectLogPath.Name = "btnSelectLogPath";
            this.btnSelectLogPath.Size = new System.Drawing.Size(53, 22);
            this.btnSelectLogPath.TabIndex = 2;
            this.btnSelectLogPath.Text = "選擇";
            this.btnSelectLogPath.UseVisualStyleBackColor = true;
            this.btnSelectLogPath.Click += new System.EventHandler(this.BtnSelectLogPath_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.cgLogListenerTrackBar);
            this.panel1.Controls.Add(this.cgLogListenerSettingCheckBox1);
            this.panel1.Controls.Add(this.cgLogListenerCheckBox6);
            this.panel1.Controls.Add(this.cgLogListenerCheckBox5);
            this.panel1.Controls.Add(this.cgLogListenerCheckBox4);
            this.panel1.Controls.Add(this.cgLogListenerCheckBox3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cgLogListenerListBox);
            this.panel1.Controls.Add(this.btnDelCus);
            this.panel1.Controls.Add(this.btnAddCus);
            this.panel1.Controls.Add(this.cgLogListenerCheckBox2);
            this.panel1.Controls.Add(this.cgLogListenerCheckBox1);
            this.panel1.Location = new System.Drawing.Point(11, 38);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 255);
            this.panel1.TabIndex = 6;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(2, 230);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(93, 16);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "Custom Notify";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // cgLogListenerTrackBar
            // 
            this.cgLogListenerTrackBar.AutoSize = false;
            this.cgLogListenerTrackBar.LargeChange = 1;
            this.cgLogListenerTrackBar.Location = new System.Drawing.Point(2, 197);
            this.cgLogListenerTrackBar.Name = "cgLogListenerTrackBar";
            this.cgLogListenerTrackBar.NameInSetting = "SoundVol";
            this.cgLogListenerTrackBar.Size = new System.Drawing.Size(108, 27);
            this.cgLogListenerTrackBar.TabIndex = 12;
            this.cgLogListenerTrackBar.Value = 5;
            // 
            // cgLogListenerSettingCheckBox1
            // 
            this.cgLogListenerSettingCheckBox1.AutoSize = true;
            this.cgLogListenerSettingCheckBox1.Location = new System.Drawing.Point(2, 172);
            this.cgLogListenerSettingCheckBox1.Name = "cgLogListenerSettingCheckBox1";
            this.cgLogListenerSettingCheckBox1.NameInSetting = "PlaySound";
            this.cgLogListenerSettingCheckBox1.RegexPattern = null;
            this.cgLogListenerSettingCheckBox1.Size = new System.Drawing.Size(72, 16);
            this.cgLogListenerSettingCheckBox1.TabIndex = 8;
            this.cgLogListenerSettingCheckBox1.Text = "播放音效";
            this.cgLogListenerSettingCheckBox1.UseVisualStyleBackColor = true;
            // 
            // cgLogListenerCheckBox6
            // 
            this.cgLogListenerCheckBox6.AutoSize = true;
            this.cgLogListenerCheckBox6.Location = new System.Drawing.Point(2, 124);
            this.cgLogListenerCheckBox6.Name = "cgLogListenerCheckBox6";
            this.cgLogListenerCheckBox6.NameInSetting = "ReMaze";
            this.cgLogListenerCheckBox6.RegexPattern = "你感覺到一股不可思議的力量，而『.*』好像快(要?)消失了。";
            this.cgLogListenerCheckBox6.Size = new System.Drawing.Size(96, 16);
            this.cgLogListenerCheckBox6.TabIndex = 8;
            this.cgLogListenerCheckBox6.Text = "迷宮重組通知";
            this.cgLogListenerCheckBox6.UseVisualStyleBackColor = true;
            // 
            // cgLogListenerCheckBox5
            // 
            this.cgLogListenerCheckBox5.AutoSize = true;
            this.cgLogListenerCheckBox5.Location = new System.Drawing.Point(2, 99);
            this.cgLogListenerCheckBox5.Name = "cgLogListenerCheckBox5";
            this.cgLogListenerCheckBox5.NameInSetting = "Sell";
            this.cgLogListenerCheckBox5.RegexPattern = "您順利賣掉了一個.*，(收入|獲得).*魔幣！";
            this.cgLogListenerCheckBox5.Size = new System.Drawing.Size(96, 16);
            this.cgLogListenerCheckBox5.TabIndex = 8;
            this.cgLogListenerCheckBox5.Text = "擺攤售出通知";
            this.cgLogListenerCheckBox5.UseVisualStyleBackColor = true;
            // 
            // cgLogListenerCheckBox4
            // 
            this.cgLogListenerCheckBox4.AutoSize = true;
            this.cgLogListenerCheckBox4.Location = new System.Drawing.Point(2, 74);
            this.cgLogListenerCheckBox4.Name = "cgLogListenerCheckBox4";
            this.cgLogListenerCheckBox4.NameInSetting = "PlayerJoin";
            this.cgLogListenerCheckBox4.RegexPattern = "加入了(你|您)的隊伍。";
            this.cgLogListenerCheckBox4.Size = new System.Drawing.Size(108, 16);
            this.cgLogListenerCheckBox4.TabIndex = 8;
            this.cgLogListenerCheckBox4.Text = "被加入隊伍通知";
            this.cgLogListenerCheckBox4.UseVisualStyleBackColor = true;
            // 
            // cgLogListenerCheckBox3
            // 
            this.cgLogListenerCheckBox3.AutoSize = true;
            this.cgLogListenerCheckBox3.Location = new System.Drawing.Point(2, 49);
            this.cgLogListenerCheckBox3.Name = "cgLogListenerCheckBox3";
            this.cgLogListenerCheckBox3.NameInSetting = "MP0";
            this.cgLogListenerCheckBox3.RegexPattern = "魔力不足。";
            this.cgLogListenerCheckBox3.Size = new System.Drawing.Size(96, 16);
            this.cgLogListenerCheckBox3.TabIndex = 8;
            this.cgLogListenerCheckBox3.Text = "魔力不足通知";
            this.cgLogListenerCheckBox3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "自訂關鍵字";
            // 
            // cgLogListenerListBox
            // 
            this.cgLogListenerListBox.FormattingEnabled = true;
            this.cgLogListenerListBox.ItemHeight = 12;
            this.cgLogListenerListBox.Location = new System.Drawing.Point(127, 20);
            this.cgLogListenerListBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cgLogListenerListBox.Name = "cgLogListenerListBox";
            this.cgLogListenerListBox.NotifyIcon = this.notifyIcon;
            this.cgLogListenerListBox.Size = new System.Drawing.Size(147, 148);
            this.cgLogListenerListBox.TabIndex = 9;
            // 
            // btnDelCus
            // 
            this.btnDelCus.Location = new System.Drawing.Point(178, 181);
            this.btnDelCus.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelCus.Name = "btnDelCus";
            this.btnDelCus.Size = new System.Drawing.Size(47, 22);
            this.btnDelCus.TabIndex = 10;
            this.btnDelCus.Text = "移除";
            this.btnDelCus.UseVisualStyleBackColor = true;
            this.btnDelCus.Click += new System.EventHandler(this.BtnDelCus_Click);
            // 
            // btnAddCus
            // 
            this.btnAddCus.Location = new System.Drawing.Point(127, 181);
            this.btnAddCus.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddCus.Name = "btnAddCus";
            this.btnAddCus.Size = new System.Drawing.Size(47, 22);
            this.btnAddCus.TabIndex = 9;
            this.btnAddCus.Text = "增加";
            this.btnAddCus.UseVisualStyleBackColor = true;
            this.btnAddCus.Click += new System.EventHandler(this.BtnAddCus_Click);
            // 
            // cgLogListenerCheckBox2
            // 
            this.cgLogListenerCheckBox2.AutoSize = true;
            this.cgLogListenerCheckBox2.Location = new System.Drawing.Point(2, 25);
            this.cgLogListenerCheckBox2.Margin = new System.Windows.Forms.Padding(2);
            this.cgLogListenerCheckBox2.Name = "cgLogListenerCheckBox2";
            this.cgLogListenerCheckBox2.NameInSetting = "ItemFull";
            this.cgLogListenerCheckBox2.RegexPattern = "物品欄沒有空位。";
            this.cgLogListenerCheckBox2.Size = new System.Drawing.Size(84, 16);
            this.cgLogListenerCheckBox2.TabIndex = 1;
            this.cgLogListenerCheckBox2.Text = "道具滿通知";
            this.cgLogListenerCheckBox2.UseVisualStyleBackColor = true;
            // 
            // cgLogListenerCheckBox1
            // 
            this.cgLogListenerCheckBox1.AutoSize = true;
            this.cgLogListenerCheckBox1.Location = new System.Drawing.Point(2, 2);
            this.cgLogListenerCheckBox1.Margin = new System.Windows.Forms.Padding(2);
            this.cgLogListenerCheckBox1.Name = "cgLogListenerCheckBox1";
            this.cgLogListenerCheckBox1.NameInSetting = "Health";
            this.cgLogListenerCheckBox1.RegexPattern = "在工作時不小心受傷了。";
            this.cgLogListenerCheckBox1.Size = new System.Drawing.Size(96, 16);
            this.cgLogListenerCheckBox1.TabIndex = 1;
            this.cgLogListenerCheckBox1.Text = "採集受傷通知";
            this.cgLogListenerCheckBox1.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExit.Location = new System.Drawing.Point(198, 300);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(89, 22);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "結束程式";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(9, 311);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(65, 12);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "關於本程式";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 333);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSelectLogPath);
            this.Controls.Add(this.txtCgLogPath);
            this.Controls.Add(this.btnExit);
            this.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "魔力Log監視";
            this.MinimumSizeChanged += new System.EventHandler(this.FormMain_MinimumSizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.notifyIconContextMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cgLogListenerTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.TextBox txtCgLogPath;
        private System.Windows.Forms.Button btnSelectLogPath;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelCus;
        private System.Windows.Forms.Button btnAddCus;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ContextMenuStrip notifyIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolOpen;
        private System.Windows.Forms.ToolStripMenuItem toolMinsize;
        private System.Windows.Forms.ToolStripSeparator toolSep1;
        private System.Windows.Forms.ToolStripMenuItem toolExit;
        private CgLogListenerListBox cgLogListenerListBox;
        private System.Windows.Forms.Label label1;
        private CgLogListenerCheckBox cgLogListenerCheckBox1;
        private CgLogListenerCheckBox cgLogListenerCheckBox2;
        private CgLogListenerCheckBox cgLogListenerCheckBox3;
        private CgLogListenerCheckBox cgLogListenerCheckBox4;
        private CgLogListenerCheckBox cgLogListenerCheckBox5;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private CgLogListenerCheckBox cgLogListenerSettingCheckBox1;
        private CgLogListenerCheckBox cgLogListenerCheckBox6;
        private CgLogListenerTrackBar cgLogListenerTrackBar;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

