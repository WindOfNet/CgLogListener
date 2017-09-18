using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CgLogListener
{
    public partial class FormMain : Form
    {
        Settings settings;
        CgLogHandler watcher;

        public FormMain()
        {
            InitializeComponent();

            // fix IME bug
            this.ImeMode = ImeMode.OnHalf;
            this.Icon = Resource.icon;
            this.notifyIcon.Icon = Resource.icon;

            settings = Settings.GetInstance();
        }

        private void frmMain_Load(object sender, System.EventArgs e)
        {
            if (!settings.Load())
            {
                // load conf err         
                MessageBox.Show(this, "讀取設定失敗", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            
            if (string.IsNullOrEmpty(settings.CgLogPath))
            {
                string cgLogPath = settings.CgLogPath;

                if (!selectLogPath(out cgLogPath))
                {
                    this.Close();
                    return;
                }

                settings.CgLogPath = cgLogPath;
                settings.ReWrite();
            }

            if (!Directory.Exists(settings.CgLogPath))
            {
                // the dir path invalid, set to default and exit
                settings.CgLogPath = string.Empty;
                settings.ReWrite();
                MessageBox.Show(this, "設定檔路徑錯誤, 請重新啟動", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            bindWatcher();

            // set playsound check
            cgLogListenerSettingCheckBox1.Checked = settings.PlaySound;
            
            // set default tips check
            foreach (CgLogListenerCheckBox chk in panel1.Controls.OfType<CgLogListenerCheckBox>())
            {
                settings.DefaultTips.TryGetValue(chk.NameInSetting, out bool enable);
                chk.Checked = enable;
            }

            // set custom tips items
            settings.CustomTips
                    .ForEach(s =>
                    {
                        if (!string.IsNullOrEmpty(s))
                        {
                            CgLogListenerListBox.Items.Add(s);
                        }
                    });
        }

        private void btnSelectLogPath_Click(object sender, System.EventArgs e)
        {
            if (selectLogPath(out string cgLogPath))
            {
                settings.CgLogPath = cgLogPath;
                settings.ReWrite();
                bindWatcher();
            }
        }

        bool selectLogPath(out string path)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog()
            {
                ShowNewFolderButton = false,
                Description = "請選擇放置魔力寶貝Log的目錄"
            };

            DialogResult result = dialog.ShowDialog(this);
            path = dialog.SelectedPath;

            return result == DialogResult.OK;
        }

        void bindWatcher()
        {
            txtCgLogPath.Text = settings.CgLogPath;
            watcher = new CgLogHandler(settings.CgLogPath);
            watcher.OnNewLog += watcher_OnNewLog;
        }

        void watcher_OnNewLog(string log)
        {
            foreach (INotifyMessage n in panel1.Controls.OfType<INotifyMessage>())
            {
                if (n.Notify(log))
                {
                    // break if one of trigger
                    break;
                }
            }
        }

        private void btnAddCus_Click(object sender, System.EventArgs e)
        {
            if (FormPrompt.ShowDialog(this, out string value) != DialogResult.OK ||
                string.IsNullOrEmpty(value))
            {
                return;
            }

            if (value.Contains("=") ||
                value.Contains(","))
            {
                MessageBox.Show(this, "不支援加入 = 或 , ", "fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            CgLogListenerListBox.AddListen(value);
        }

        private void btnDelCus_Click(object sender, EventArgs e)
        {
            if (CgLogListenerListBox.SelectedIndex < 0)
            {
                return;
            }

            string selectItem = (string)CgLogListenerListBox.SelectedItem;
            CgLogListenerListBox.RemoveListen(selectItem);
        }

        #region notifyIcon, window minsize and exit ...

        private void notifyIcon_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void toolOpen_Click(object sender, System.EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void toolMinsize_Click(object sender, System.EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void toolExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void FormMain_MinimumSizeChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
            }
        }
        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/WindOfNet/CgLogListener");
        }
    }
}
