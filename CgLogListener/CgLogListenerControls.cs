using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CgLogListener
{
    public class CgLogListenerCheckBox : CheckBox, INotifyMessage
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

        public void Notify(string message)
        {
            if (this.Checked &&
                Regex.IsMatch(message, RegexPattern))
            {
                NotifyIcon?.ShowBalloonTip(10000, NotifyIcon.BalloonTipTitle, message, ToolTipIcon.Info);
                SoundPlayer player = new SoundPlayer
                {
                    Stream = Resource.sound
                };
                player.Play();
            }
        }
    }

    public class CgLogListenerListBox : ListBox, INotifyMessage
    {
        public NotifyIcon NotifyIcon { get; set; }

        public void Notify(string message)
        {
            foreach (string s in this.Items)
            {
                if (Regex.IsMatch(message, s))
                {
                    NotifyIcon?.ShowBalloonTip(10000, NotifyIcon.BalloonTipTitle, message, ToolTipIcon.Info);
                    SoundPlayer player = new SoundPlayer
                    {
                        Stream = Resource.sound
                    };
                    player.Play();
                }
            }
        }
    }
}
