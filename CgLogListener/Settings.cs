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

        string settingsFilePath = null;
        string customizeFilePath = null;

        public bool PlaySound { get; set; }
        public int SoundVol { get; set; }
        public string CgLogPath { get; set; }
        public Dictionary<string, bool> DefaultTips { get; private set; }
        public List<string> CustomizeTips { get; private set; }

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
            const string customizeFileName = "customize.conf";
            DefaultTips = new Dictionary<string, bool>();
            CustomizeTips = new List<string>();

            this.settingsFilePath = settingFilePath ?? Path.Combine(Directory.GetCurrentDirectory(), settingsFileName);
            this.customizeFilePath = Path.Combine(Directory.GetCurrentDirectory(), customizeFileName);

            if (!File.Exists(this.settingsFilePath))
            {
                // gen new conf file
                genConfig(this.settingsFilePath);
            }

            try
            {
                // load default settings
                loadDefaultSettings();

                // load customize tips
                loadCustomizeTips();

                return true;
            }
            catch { return false; }
        }

        private void loadDefaultSettings()
        {
            using (FileStream fs = new FileStream(this.settingsFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
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
                        case "SoundVol":
                            SoundVol = int.Parse(conf[1]);
                            break;                           
                        default:
                            DefaultTips[conf[0]] = int.Parse(conf[1]) == 1;
                            break;
                    }

                    line = sr.ReadLine();
                }
            }
        }
        
        private void loadCustomizeTips()
        {
            using (FileStream fs = new FileStream(this.customizeFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            using (StreamReader sr = new StreamReader(fs))
            {
                string line = sr.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    CustomizeTips.Add(line);
                    line = sr.ReadLine();
                }
            }
        }

        void genConfig(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine($"CgLogPath=");
                sw.WriteLine($"PlaySound=1");
                sw.WriteLine($"SoundVol=5");
            }
        }

        public void ReWrite()
        {
            using (FileStream fs = new FileStream(settingsFilePath, FileMode.Create, FileAccess.ReadWrite))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine($"CgLogPath={CgLogPath}");
                sw.WriteLine($"PlaySound={(PlaySound ? 1 : 0)}");
                sw.WriteLine($"SoundVol={SoundVol}");
                foreach (KeyValuePair<string, bool> kv in DefaultTips)
                {
                    sw.WriteLine($"{kv.Key}={(kv.Value ? 1 : 0)}");
                }
            }

            using (FileStream fs = new FileStream(customizeFilePath, FileMode.Create, FileAccess.ReadWrite))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                foreach (string s in CustomizeTips)
                {
                    sw.WriteLine(s);
                }
            }
        }
    }
}
