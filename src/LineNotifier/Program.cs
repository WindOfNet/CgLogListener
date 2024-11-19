using System;
using System.IO;
using IniParser;

namespace LineNotifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string iniFilename = "LineNotifier.ini";

            if (!File.Exists(iniFilename))
            {
                return;
            }

            try
            {
                var ini = new FileIniDataParser().ReadFile(iniFilename);
                if (ini.TryGetKey("token", out var token) && !string.IsNullOrEmpty(token))
                {
                    LineNotifyHelper.Notify(token, args[0]).Wait();
                }
            }
            catch { }
        }
    }
}
