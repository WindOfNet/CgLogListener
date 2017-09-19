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
            this.cgLogListenerSettingCheckBox1 = new CgLogListener.CgLogListenerSettingCheckBox();
            this.cgLogListenerCheckBox5 = new CgLogListener.CgLogListenerCheckBox();
            this.CgLogListenerCheckBox4 = new CgLogListener.CgLogListenerCheckBox();
            this.CgLogListenerCheckBox3 = new CgLogListener.CgLogListenerCheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CgLogListenerListBox = new CgLogListener.CgLogListenerListBox();
            this.btnDelCus = new System.Windows.Forms.Button();
            this.btnAddCus = new System.Windows.Forms.Button();
            this.CgLogListenerCheckBox2 = new CgLogListener.CgLogListenerCheckBox();
            this.CgLogListenerCheckBox1 = new CgLogListener.CgLogListenerCheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cgLogListenerCheckBox6 = new CgLogListener.CgLogListenerCheckBox();
            this.notifyIconContextMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipTitle = "魔力Log監視";
            this.notifyIcon.ContextMenuStrip = this.notifyIconContextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "魔力Log監視";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
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
            this.notifyIconContextMenu.Size = new System.Drawing.Size(99, 82);
            // 
            // toolOpen
            // 
            this.toolOpen.Name = "toolOpen";
            this.toolOpen.Size = new System.Drawing.Size(98, 24);
            this.toolOpen.Text = "開啟";
            this.toolOpen.Click += new System.EventHandler(this.toolOpen_Click);
            // 
            // toolMinsize
            // 
            this.toolMinsize.Name = "toolMinsize";
            this.toolMinsize.Size = new System.Drawing.Size(98, 24);
            this.toolMinsize.Text = "最小化";
            this.toolMinsize.Click += new System.EventHandler(this.toolMinsize_Click);
            // 
            // toolSep1
            // 
            this.toolSep1.Name = "toolSep1";
            this.toolSep1.Size = new System.Drawing.Size(95, 6);
            // 
            // toolExit
            // 
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(98, 24);
            this.toolExit.Text = "結束";
            this.toolExit.Click += new System.EventHandler(this.toolExit_Click);
            // 
            // txtCgLogPath
            // 
            this.txtCgLogPath.Location = new System.Drawing.Point(11, 9);
            this.txtCgLogPath.Margin = new System.Windows.Forms.Padding(2);
            this.txtCgLogPath.Name = "txtCgLogPath";
            this.txtCgLogPath.ReadOnly = true;
            this.txtCgLogPath.Size = new System.Drawing.Size(219, 25);
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
            this.btnSelectLogPath.Click += new System.EventHandler(this.btnSelectLogPath_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cgLogListenerSettingCheckBox1);
            this.panel1.Controls.Add(this.cgLogListenerCheckBox6);
            this.panel1.Controls.Add(this.cgLogListenerCheckBox5);
            this.panel1.Controls.Add(this.CgLogListenerCheckBox4);
            this.panel1.Controls.Add(this.CgLogListenerCheckBox3);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CgLogListenerListBox);
            this.panel1.Controls.Add(this.btnDelCus);
            this.panel1.Controls.Add(this.btnAddCus);
            this.panel1.Controls.Add(this.CgLogListenerCheckBox2);
            this.panel1.Controls.Add(this.CgLogListenerCheckBox1);
            this.panel1.Location = new System.Drawing.Point(11, 38);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 205);
            this.panel1.TabIndex = 6;
            // 
            // cgLogListenerSettingCheckBox1
            // 
            this.cgLogListenerSettingCheckBox1.AutoSize = true;
            this.cgLogListenerSettingCheckBox1.Location = new System.Drawing.Point(2, 155);
            this.cgLogListenerSettingCheckBox1.Name = "cgLogListenerSettingCheckBox1";
            this.cgLogListenerSettingCheckBox1.NameInSetting = "PlaySound";
            this.cgLogListenerSettingCheckBox1.Size = new System.Drawing.Size(89, 19);
            this.cgLogListenerSettingCheckBox1.TabIndex = 8;
            this.cgLogListenerSettingCheckBox1.Text = "播放音效";
            this.cgLogListenerSettingCheckBox1.UseVisualStyleBackColor = true;
            // 
            // cgLogListenerCheckBox5
            // 
            this.cgLogListenerCheckBox5.AutoSize = true;
            this.cgLogListenerCheckBox5.Location = new System.Drawing.Point(2, 99);
            this.cgLogListenerCheckBox5.Name = "cgLogListenerCheckBox5";
            this.cgLogListenerCheckBox5.NameInSetting = "Sell";
            this.cgLogListenerCheckBox5.RegexPattern = "您順利賣掉了一個.*，(收入|獲得).*魔幣！";
            this.cgLogListenerCheckBox5.Size = new System.Drawing.Size(119, 19);
            this.cgLogListenerCheckBox5.TabIndex = 8;
            this.cgLogListenerCheckBox5.Text = "擺攤售出通知";
            this.cgLogListenerCheckBox5.ToolTipText = "擺攤物品售出";
            this.cgLogListenerCheckBox5.UseVisualStyleBackColor = true;
            // 
            // CgLogListenerCheckBox4
            // 
            this.CgLogListenerCheckBox4.AutoSize = true;
            this.CgLogListenerCheckBox4.Location = new System.Drawing.Point(2, 74);
            this.CgLogListenerCheckBox4.Name = "CgLogListenerCheckBox4";
            this.CgLogListenerCheckBox4.NameInSetting = "PlayerJoin";
            this.CgLogListenerCheckBox4.RegexPattern = "加入了(你|您)的隊伍。";
            this.CgLogListenerCheckBox4.Size = new System.Drawing.Size(134, 19);
            this.CgLogListenerCheckBox4.TabIndex = 8;
            this.CgLogListenerCheckBox4.Text = "被加入隊伍通知";
            this.CgLogListenerCheckBox4.ToolTipText = "當有人加入隊伍";
            this.CgLogListenerCheckBox4.UseVisualStyleBackColor = true;
            // 
            // CgLogListenerCheckBox3
            // 
            this.CgLogListenerCheckBox3.AutoSize = true;
            this.CgLogListenerCheckBox3.Location = new System.Drawing.Point(2, 49);
            this.CgLogListenerCheckBox3.Name = "CgLogListenerCheckBox3";
            this.CgLogListenerCheckBox3.NameInSetting = "MP0";
            this.CgLogListenerCheckBox3.RegexPattern = "魔力不足。";
            this.CgLogListenerCheckBox3.Size = new System.Drawing.Size(119, 19);
            this.CgLogListenerCheckBox3.TabIndex = 8;
            this.CgLogListenerCheckBox3.Text = "魔力不足通知";
            this.CgLogListenerCheckBox3.ToolTipText = "採集到魔力不足";
            this.CgLogListenerCheckBox3.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExit.Location = new System.Drawing.Point(0, 181);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(89, 22);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "結束程式";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "自訂關鍵字";
            // 
            // CgLogListenerListBox
            // 
            this.CgLogListenerListBox.FormattingEnabled = true;
            this.CgLogListenerListBox.ItemHeight = 15;
            this.CgLogListenerListBox.Location = new System.Drawing.Point(127, 20);
            this.CgLogListenerListBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CgLogListenerListBox.Name = "CgLogListenerListBox";
            this.CgLogListenerListBox.NotifyIcon = this.notifyIcon;
            this.CgLogListenerListBox.Size = new System.Drawing.Size(147, 154);
            this.CgLogListenerListBox.TabIndex = 9;
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
            this.btnDelCus.Click += new System.EventHandler(this.btnDelCus_Click);
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
            this.btnAddCus.Click += new System.EventHandler(this.btnAddCus_Click);
            // 
            // CgLogListenerCheckBox2
            // 
            this.CgLogListenerCheckBox2.AutoSize = true;
            this.CgLogListenerCheckBox2.Location = new System.Drawing.Point(2, 25);
            this.CgLogListenerCheckBox2.Margin = new System.Windows.Forms.Padding(2);
            this.CgLogListenerCheckBox2.Name = "CgLogListenerCheckBox2";
            this.CgLogListenerCheckBox2.NameInSetting = "ItemFull";
            this.CgLogListenerCheckBox2.RegexPattern = "物品欄沒有空位。";
            this.CgLogListenerCheckBox2.Size = new System.Drawing.Size(104, 19);
            this.CgLogListenerCheckBox2.TabIndex = 1;
            this.CgLogListenerCheckBox2.Text = "道具滿通知";
            this.CgLogListenerCheckBox2.ToolTipText = "採集到道具欄滿格";
            this.CgLogListenerCheckBox2.UseVisualStyleBackColor = true;
            // 
            // CgLogListenerCheckBox1
            // 
            this.CgLogListenerCheckBox1.AutoSize = true;
            this.CgLogListenerCheckBox1.Location = new System.Drawing.Point(2, 2);
            this.CgLogListenerCheckBox1.Margin = new System.Windows.Forms.Padding(2);
            this.CgLogListenerCheckBox1.Name = "CgLogListenerCheckBox1";
            this.CgLogListenerCheckBox1.NameInSetting = "Health";
            this.CgLogListenerCheckBox1.RegexPattern = "在工作時不小心受傷了。";
            this.CgLogListenerCheckBox1.Size = new System.Drawing.Size(119, 19);
            this.CgLogListenerCheckBox1.TabIndex = 1;
            this.CgLogListenerCheckBox1.Text = "採集受傷通知";
            this.CgLogListenerCheckBox1.ToolTipText = "採集時受傷";
            this.CgLogListenerCheckBox1.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(8, 245);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(82, 15);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "關於本程式";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // cgLogListenerCheckBox6
            // 
            this.cgLogListenerCheckBox6.AutoSize = true;
            this.cgLogListenerCheckBox6.Location = new System.Drawing.Point(2, 124);
            this.cgLogListenerCheckBox6.Name = "cgLogListenerCheckBox6";
            this.cgLogListenerCheckBox6.NameInSetting = "ReMaze";
            this.cgLogListenerCheckBox6.RegexPattern = "你感覺到一股不可思議的力量，而『.*』好像快(要?)消失了。";
            this.cgLogListenerCheckBox6.Size = new System.Drawing.Size(119, 19);
            this.cgLogListenerCheckBox6.TabIndex = 8;
            this.cgLogListenerCheckBox6.Text = "迷宮重組通知";
            this.cgLogListenerCheckBox6.ToolTipText = "迷宮重組";
            this.cgLogListenerCheckBox6.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 260);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSelectLogPath);
            this.Controls.Add(this.txtCgLogPath);
            this.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "魔力Log監視";
            this.MinimumSizeChanged += new System.EventHandler(this.FormMain_MinimumSizeChanged);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.notifyIconContextMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private CgLogListenerListBox CgLogListenerListBox;
        private System.Windows.Forms.Label label1;
        private CgLogListenerCheckBox CgLogListenerCheckBox1;
        private CgLogListenerCheckBox CgLogListenerCheckBox2;
        private CgLogListenerCheckBox CgLogListenerCheckBox3;
        private CgLogListenerCheckBox CgLogListenerCheckBox4;
        private CgLogListenerCheckBox cgLogListenerCheckBox5;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private CgLogListenerSettingCheckBox cgLogListenerSettingCheckBox1;
        private CgLogListenerCheckBox cgLogListenerCheckBox6;
    }
}

