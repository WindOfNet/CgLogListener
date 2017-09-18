using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CgLogListener
{
    public class CgLogListenerSettingCheckBox : CheckBox
    {
        public string NameInSetting { get; set; }

        protected override void OnClick(EventArgs e)
        {
            Settings settings = Settings.GetInstance();
            settings.DefaultTips[NameInSetting] = !this.Checked;
            settings.ReWrite();
            base.OnClick(e);
        }
    }
    
    public class CgLogListenerCheckBox : CgLogListenerSettingCheckBox, INotifyMessage
    {
        ToolTip tooltip;
        string toolTipText = null; // for form design

        public NotifyIcon NotifyIcon { get; set; }
        public string RegexPattern { get; set; }
        public string ToolTipText
        {
            get => toolTipText;
            set
            {
                tooltip = new ToolTip();
                tooltip.SetToolTip(this, toolTipText = value);
            }
        }

        public bool Notify(string message)
        {
            Settings settings = Settings.GetInstance();

            if (settings.DefaultTips.TryGetValue(NameInSetting, out bool value) &&
                value &&
                Regex.IsMatch(message, RegexPattern))
            {
                NotifyIcon?.ShowBalloonTip(10000, NotifyIcon.BalloonTipTitle, message, ToolTipIcon.None);
                PlaySoundHelper.PlaySound();

                return true;
            }

            return false;
        }
    }

    public class CgLogListenerListBox : ListBox, INotifyMessage
    {
        public NotifyIcon NotifyIcon { get; set; }

        public void AddListen(string rule)
        {
            Settings settings = Settings.GetInstance();
            settings.CustomTips.Add(rule);
            settings.ReWrite();
            this.Items.Add(rule);
        }

        public void RemoveListen(string rule)
        {
            Settings settings = Settings.GetInstance();
            settings.CustomTips.Remove(rule);
            settings.ReWrite();
            this.Items.Remove(rule);
        }

        public bool Notify(string message)
        {
            Settings settings = Settings.GetInstance();
            foreach (string s in settings.CustomTips)
            {
                if (Regex.IsMatch(message, s))
                {
                    NotifyIcon?.ShowBalloonTip(10000, NotifyIcon.BalloonTipTitle, message, ToolTipIcon.None);
                    PlaySoundHelper.PlaySound();

                    return true;
                }
            }

            return false;
        }
    }
}
