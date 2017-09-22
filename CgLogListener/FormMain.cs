using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
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
                return;
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

            if (!Directory.Exists(settings.CgLogPath) ||
                !CgLogHandler.ValidationPath(settings.CgLogPath))
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

            // set playsound vol
            cgLogListenerTrackBar.Value = settings.SoundVol;

            // set default tips check
            foreach (CgLogListenerCheckBox chk in panel1.Controls.OfType<CgLogListenerCheckBox>())
            {
                settings.DefaultTips.TryGetValue(chk.NameInSetting, out bool enable);
                chk.Checked = enable;
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
        }

        private void CgLogListenerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CgLogListenerSettingCheckBox chk = (CgLogListenerSettingCheckBox)sender;
            settings.DefaultTips[chk.NameInSetting] = chk.Checked;
            settings.ReWrite();
        }

        private void CgLogListenerSettingCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            settings.PlaySound = cgLogListenerSettingCheckBox1.Checked;
            settings.ReWrite();
        }

        private void CgLogListenerTrackBar_ValueChanged(object sender, EventArgs e)
        {
            settings.SoundVol = cgLogListenerTrackBar.Value;
            settings.ReWrite();
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
            path = null;
            DialogResult result = DialogResult.No;
            FolderBrowserDialog dialog = new FolderBrowserDialog()
            {
                ShowNewFolderButton = false,
                Description = @"請選擇魔力寶貝的目錄 (e.g. D:\CrossGate\)"
            };

            while (true)
            {
                result = dialog.ShowDialog(this);

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
                    notifyIcon.ShowBalloonTip(10000, notifyIcon.BalloonTipTitle, log, ToolTipIcon.None);

                    if (!settings.PlaySound)
                    {
                        return;
                    }
                    const string wavName = "sound.wav";
                    string wavPath = Path.Combine(Directory.GetCurrentDirectory(), wavName);
                    Stream wavStream = null;

                    try
                    {
                        if (!File.Exists(wavPath))
                        {
                            // set default wav
                            wavStream = Resource.sound;
                        }
                        else
                        {
                            wavStream = File.Open(wavPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        }

                        WaveStream wave = new WaveFileReader(wavStream);
                        WaveChannel32 volumeStream = new WaveChannel32(wave);
                        WaveOutEvent waveOut = new WaveOutEvent();
                        waveOut.Volume = (float)this.Invoke((Func<float>)delegate { return cgLogListenerTrackBar.Value / 10f; });
                        waveOut.Init(volumeStream);
                        waveOut.Play();
                    }
                    catch { }

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

            cgLogListenerListBox.AddListen(value);
        }

        private void btnDelCus_Click(object sender, EventArgs e)
        {
            if (cgLogListenerListBox.SelectedIndex < 0)
            {
                return;
            }

            string selectItem = (string)cgLogListenerListBox.SelectedItem;
            cgLogListenerListBox.RemoveListen(selectItem);
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
