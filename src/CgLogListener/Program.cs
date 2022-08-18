using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace CgLogListener
{
    static class Program
    {
        static Mutex _mutex;
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createNew;
            
            Attribute guid_attr = Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(GuidAttribute));
            string guid = ((GuidAttribute)guid_attr).Value;
            _mutex = new Mutex(true, guid, out createNew);

            if (false == createNew)
            {
                MessageBox.Show("已經有正在執行的CgLogListener", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            _mutex.ReleaseMutex();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
