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
        string latestLog;
        public delegate void onNewLog(string message);
        public event onNewLog OnNewLog;

        public CgLogHandler(string path)
        {
            if (string.IsNullOrEmpty(path) ||
                !Directory.Exists(path) ||
                !ValidationPath(path))
                throw new ArgumentException();

            logPath = Path.Combine(path, "Log");
            FileSystemWatcher fsw = new FileSystemWatcher(logPath);
            fsw.Filter = "*.txt";
            fsw.NotifyFilter = NotifyFilters.LastWrite;
            fsw.EnableRaisingEvents = true;
            fsw.Changed += Fsw_Changed;
        }

        public static bool ValidationPath(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    return false;
                }
                                
                if (Directory.Exists(Path.Combine(path, "Log")))
                {
                    return true;
                }

                return false;
            }
            catch { return false; }
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
                    string log = Encoding.UTF8.GetString(b).Replace("", " ");
                    /* 
                     * 多視窗時可能會連續偵測到相同的句子 (並且時間會一樣)
                     * 所以會有一個變數去紀錄最後的 log, 並拿來比對當次的 log
                     * 若 not equals 才會觸發事件
                     */
                    if (!log.Equals(latestLog))
                    {
                        latestLog = log;
                        OnNewLog?.Invoke(log);
                    }
                }
            }
            catch { }
        }
    }
}
