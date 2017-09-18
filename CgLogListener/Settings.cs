using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CgLogListener
{
    public sealed class Settings
    {
        static object locker = new object();
        static Settings instance;

        string settingFilePath = null;

        public bool IsLoad { get; private set; }
        public bool PlaySound { get; private set; }
        public string CgLogPath { get; set; }
        public Dictionary<string, bool> DefaultTips { get; private set; }
        public List<string> CustomTips { get; private set; }

        Settings() { }

        public static Settings GetInstance()
        {
            lock (locker)
            {
                if (instance == null)
                {
                    instance = new Settings();
                }

                return instance;
            }
        }

        public bool Load(string settingFilePath = null)
        {
            const string settingsFileName = "settings.conf";
            DefaultTips = new Dictionary<string, bool>();
            CustomTips = new List<string>();

            this.settingFilePath = settingFilePath ?? Path.Combine(Directory.GetCurrentDirectory(), settingsFileName);
            if (!File.Exists(this.settingFilePath))
            {
                // gen new conf file
                genConfig(this.settingFilePath);
            }

            try
            {
                using (FileStream fs = new FileStream(this.settingFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                using (StreamReader sr = new StreamReader(fs))
                {
                    string line = sr.ReadLine();
                    while (!string.IsNullOrEmpty(line))
                    {
                        string[] conf = line.Split('=');
                        if (conf.Length != 2)
                        {
                            line = sr.ReadLine();
                            continue;
                        }

                        switch (conf[0])
                        {
                            case "CgLogPath":
                                CgLogPath = conf[1];
                                break;
                            case "PlaySound":
                                PlaySound = int.Parse(conf[1]) == 1;
                                break;
                            case "CustomTips":
                                CustomTips.AddRange(conf[1].Split(','));
                                break;
                            default:
                                DefaultTips[conf[0]] = int.Parse(conf[1]) == 1;
                                break;
                        }

                        line = sr.ReadLine();
                    }

                    IsLoad = true;
                    return true;
                }
            }
            catch { return false; }
        }

        void genConfig(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine($"CgLogPath=");
                sw.WriteLine($"PlaySound=1");
                sw.WriteLine($"CustomTips=發現(野生一級|１級怪)");
            }
        }

        public void ReWrite()
        {
            using (FileStream fs = new FileStream(settingFilePath, FileMode.Create, FileAccess.ReadWrite))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine($"CgLogPath={CgLogPath}");
                sw.WriteLine($"PlaySound={(PlaySound ? 1 : 0)}");
                sw.WriteLine($"CustomTips={string.Join(",", CustomTips)}");
                foreach (KeyValuePair<string, bool> kv in DefaultTips)
                {
                    sw.WriteLine($"{kv.Key}={(kv.Value ? 1 : 0)}");
                }
            }
        }
    }
}
