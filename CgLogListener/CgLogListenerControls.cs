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
    }
    
    public class CgLogListenerCheckBox : CgLogListenerSettingCheckBox, INotifyMessage
    {
        ToolTip tooltip;
        string toolTipText = null; // for form design

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
                return true;
            }

            return false;
        }
    }

    public class CgLogListenerTrackBar : TrackBar
    {
        public string NameInSetting { get; set; }
    }

    public class CgLogListenerListBox : ListBox, INotifyMessage
    {
        public NotifyIcon NotifyIcon { get; set; }

        public void AddListen(string rule)
        {
            Settings settings = Settings.GetInstance();
            settings.CustomizeTips.Add(rule);
            settings.ReWrite();
            this.Items.Add(rule);
        }

        public void RemoveListen(string rule)
        {
            Settings settings = Settings.GetInstance();
            settings.CustomizeTips.Remove(rule);
            settings.ReWrite();
            this.Items.Remove(rule);
        }

        public bool Notify(string message)
        {
            Settings settings = Settings.GetInstance();
            foreach (string s in settings.CustomizeTips)
            {
                var split = s.Split('|');

                if (message.Contains(split[0]))
                {
                    if (split.Length > 1)
                    {
                        var exps = split[1].Split(',');

                        return !exps.Any(x => message.Contains(x));// !message.Contains(split[1]);
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
