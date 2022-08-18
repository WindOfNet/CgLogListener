using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CgLogListener
{
    public class CgLogListenerCheckBox : CheckBox, INotifyMessage
    {
        public string NameInSetting { get; set; }
        public string RegexPattern { get; set; }

        public bool Notify(string message)
        {
            var settings = Settings.GetInstance();

            if (settings.StandardTips.TryGetValue(NameInSetting, out bool value) &&
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

        public bool Notify(string message)
        {
            var settings = Settings.GetInstance();
            foreach (var s in settings.CustomizeTips)
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
