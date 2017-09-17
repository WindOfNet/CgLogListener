using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CgLogListener
{
    public class Settings
    {
        const string settingsFileName = "settings.conf";
        string settingFilePath = null;

        public string CgLogPath { get; set; }
        public List<string> CustomTips { get; set; } = new List<string>();

        public bool Load(string settingFilePath = null)
        {
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
                    Type t = this.GetType();
                    string line = sr.ReadLine();
                    while (!string.IsNullOrEmpty(line))
                    {
                        string[] conf = line.Split('=');
                        if (conf.Length != 2)
                        {
                            continue;
                        }

                        if (conf[0].Equals("CustomTips"))
                        {
                            CustomTips = conf[1].Split(',')
                                                .ToList();
                        }
                        else
                        {
                            t.GetProperty(conf[0])?
                             .SetValue(this, conf[1], null);
                        }

                        line = sr.ReadLine();
                    }

                    return true;
                }
            }
            catch { return false; }
        }

        private void genConfig(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine($"CgLogPath=");
                sw.WriteLine($"CustomTips=發現野生一級怪物");
            }
        }

        public void ReWrite()
        {
            using (FileStream fs = new FileStream(settingFilePath, FileMode.Create, FileAccess.ReadWrite))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine($"CgLogPath={CgLogPath}");
                sw.WriteLine($"CustomTips={string.Join(",", CustomTips)}");
            }
        }
    }
}
