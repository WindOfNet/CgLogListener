using System;
using System.IO;
using IniParser;

namespace DiscordNotifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string iniFilename = "DiscordNotifier.ini";

            if (!File.Exists(iniFilename))
            {
                return;
            }

            try
            {
                var ini = new FileIniDataParser().ReadFile(iniFilename);
                if (ini.TryGetKey("webhookUrl", out var webhookUrl) && !string.IsNullOrEmpty(webhookUrl))
                {
                    DiscordNotifyHelper.Notify(webhookUrl, args[0]).Wait();
                }
            }
            catch
            {
                // ignored
            }
        }
    }
}