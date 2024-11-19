using IniParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramNotifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string iniFilename = "TelegramNotifier.ini";

            if (!File.Exists(iniFilename))
            {
                return;
            }

            try
            {
                var ini = new FileIniDataParser().ReadFile(iniFilename);
                if (ini.TryGetKey("token", out var token) && 
                    !string.IsNullOrEmpty(token) &&
                    ini.TryGetKey("chat_id", out var chatId) &&
                    !string.IsNullOrEmpty(chatId))
                {
                    TelegramNotifyHelper.Notify(token, chatId, args[0]).Wait();
                }
            }
            catch { }
        }
    }
}
