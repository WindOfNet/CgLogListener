using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CgLogListener
{
    public class CgLogHandler
    {
        string logPath;
        public delegate void onNewLog(string message);
        public event onNewLog OnNewLog;

        public CgLogHandler(string path)
        {
            if (string.IsNullOrEmpty(path) ||
                !Directory.Exists(path))
                throw new ArgumentException();

            logPath = path;
            FileSystemWatcher fsw = new FileSystemWatcher(path);
            fsw.Filter = "*.txt";
            fsw.NotifyFilter = NotifyFilters.LastWrite;
            fsw.EnableRaisingEvents = true;
            fsw.Changed += Fsw_Changed;
        }

        private void Fsw_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                using (Stream stream = new FileStream(e.FullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    long l = stream.Length - 2;
                    stream.Seek(l, SeekOrigin.Begin);
                    Stack<byte> stack = new Stack<byte>();
                    while (true)
                    {
                        stream.Seek(--l, SeekOrigin.Begin);
                        int tmp = stream.ReadByte();
                        if (tmp == '\n')
                            break;
                        else
                            stack.Push((byte)tmp);                        
                    }

                    byte[] native = stack.ToArray();
                    byte[] b = Encoding.Convert(Encoding.Default, Encoding.UTF8, native);
                    OnNewLog?.Invoke(Encoding.UTF8.GetString(b).Replace("", " "));
                }
            }
            catch { }
        }
    }
}
