using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media;

namespace CgLogListener
{
    public partial class FormMain : Form
    {
        private Settings settings;
        private CgLogHandler watcher;
        private readonly MediaPlayer mp = new MediaPlayer();

        public FormMain()
        {
            InitializeComponent();

            // fix IME bug
            ImeMode = ImeMode.OnHalf;
            Icon = Resource.icon;
            notifyIcon.Icon = Resource.icon;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            settings = Settings.GetInstance();

            if (string.IsNullOrEmpty(settings.CgLogPath))
            {
                string cgLogPath = settings.CgLogPath;

                if (!SelectLogPath(out cgLogPath))
                {
                    this.Close();
                    return;
                }

                settings.SetCgLogPath(cgLogPath);
            }

            if (!Directory.Exists(settings.CgLogPath) || !CgLogHandler.ValidationPath(settings.CgLogPath))
            {
                // the dir path invalid, set to default and exit
                settings.SetCgLogPath(string.Empty);
                MessageBox.Show(this, "設定檔路徑錯誤, 請重新啟動", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            BindWatcher();

            // set playsound check
            cgLogListenerSettingCheckBox1.Checked = settings.PlaySound;

            // set playsound vol
            cgLogListenerTrackBar.Value = settings.SoundVol;

            // set line notify
            checkBox1.Checked = settings.LineNotify;

            // set default tips check
            foreach (var chk in panel1.Controls.OfType<CgLogListenerCheckBox>())
            {
                // skip playsound
                if (chk == cgLogListenerSettingCheckBox1) { continue; }

                settings.StandardTips.TryGetValue(chk.NameInSetting, out bool isEnable);
                chk.Checked = isEnable;
            }

            // set custom tips items
            settings.CustomizeTips
                    .ForEach(s =>
                    {
                        if (!string.IsNullOrEmpty(s))
                        {
                            cgLogListenerListBox.Items.Add(s);
                        }
                    });

            cgLogListenerCheckBox1.CheckedChanged += CgLogListenerCheckBox_CheckedChanged;
            cgLogListenerCheckBox2.CheckedChanged += CgLogListenerCheckBox_CheckedChanged;
            cgLogListenerCheckBox3.CheckedChanged += CgLogListenerCheckBox_CheckedChanged;
            cgLogListenerCheckBox4.CheckedChanged += CgLogListenerCheckBox_CheckedChanged;
            cgLogListenerCheckBox5.CheckedChanged += CgLogListenerCheckBox_CheckedChanged;
            cgLogListenerCheckBox6.CheckedChanged += CgLogListenerCheckBox_CheckedChanged;
            cgLogListenerSettingCheckBox1.CheckedChanged += CgLogListenerSettingCheckBox1_CheckedChanged;
            cgLogListenerTrackBar.ValueChanged += CgLogListenerTrackBar_ValueChanged;
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
        }

        private void CgLogListenerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var chk = (CgLogListenerCheckBox)sender;
            settings.SetStandardTip(chk.NameInSetting, chk.Checked);
        }

        private void CgLogListenerSettingCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            var chk = (CgLogListenerCheckBox)sender;
            settings.SetPlaySound(chk.Checked);
        }

        private void CgLogListenerTrackBar_ValueChanged(object sender, EventArgs e)
        {
            var bar = (CgLogListenerTrackBar)sender;
            settings.SetSoundVol(bar.Value);
        }

        private void BtnSelectLogPath_Click(object sender, EventArgs e)
        {
            if (SelectLogPath(out _))
            {
                watcher.Dispose();
                BindWatcher();
            }
        }

        bool SelectLogPath(out string path)
        {
            path = null;
            var dialog = new FolderBrowserDialog()
            {
                ShowNewFolderButton = false,
                Description = @"請選擇魔力寶貝的目錄 (e.g. D:\CrossGate\)"
            };

            while (true)
            {
                var result = dialog.ShowDialog(this);

                if (result == DialogResult.Cancel)
                {
                    return false;
                }

                if (result == DialogResult.OK)
                {
                    if (!CgLogHandler.ValidationPath(dialog.SelectedPath))
                    {
                        MessageBox.Show(this, "請選擇魔力寶貝的目錄", "錯誤的路徑", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    path = dialog.SelectedPath;
                    return true;
                }
            }
        }

        void BindWatcher()
        {
            txtCgLogPath.Text = settings.CgLogPath;
            watcher = new CgLogHandler(settings.CgLogPath);
            watcher.OnNewLog += Watcher_OnNewLog;
        }

        async void Watcher_OnNewLog(string log)
        {
            foreach (var n in panel1.Controls.OfType<INotifyMessage>())
            {
                if (n.Notify(log))
                {
                    notifyIcon.ShowBalloonTip(1, notifyIcon.BalloonTipTitle, log, ToolTipIcon.None);

                    const string soundName = "sound.wav";
                    if (settings.PlaySound && File.Exists(soundName))
                    {
                        Invoke((Action)delegate
                        {
                            mp.Stop();
                            mp.Open(new Uri(new FileInfo(soundName).FullName));
                            mp.Volume = settings.SoundVol / 10d;
                            mp.Play();
                        });
                    }

                    if (settings.LineNotify)
                    {
                        var lineToken = settings.LineTokey;
                        if (!string.IsNullOrEmpty(lineToken))
                        {
                            await LineNotifyHelper.Notify(lineToken, log);
                        }
                    }

                    // break if was trigger
                    break;
                }
            }
        }

        private void BtnAddCus_Click(object sender, EventArgs e)
        {
            if (FormPrompt.ShowDialog(this, out string value) != DialogResult.OK ||
                string.IsNullOrEmpty(value))
            {
                return;
            }

            settings.AddCustmizeTip(value);
            cgLogListenerListBox.Items.Add(value);
        }

        private void BtnDelCus_Click(object sender, EventArgs e)
        {
            if (cgLogListenerListBox.SelectedIndex < 0)
            {
                return;
            }

            var selectItem = (string)cgLogListenerListBox.SelectedItem;
            settings.RemoveCustmizeTip(selectItem);
            cgLogListenerListBox.Items.Remove(selectItem);
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                FormLineTokenPrompt.ShowDialog(this, out string value);
                settings.SetLineNotify(true);
                settings.SetLineTokey(value);
            }
            else
            {
                settings.SetLineNotify(false);
                settings.SetLineTokey(string.Empty);
            }
        }

        #region notifyIcon, window minsize and exit ...

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
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

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolOpen_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void ToolMinsize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ToolExit_Click(object sender, EventArgs e)
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

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            watcher?.Dispose();
            notifyIcon?.Dispose();
        }

        #endregion

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/WindOfNet/CgLogListener");
        }
    }
}
