using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTA_DEV_RECONNECT
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Mutex mutex = new Mutex(false, "F2950FA3-15C4-4A06-830E-A954A272A95F", out bool mutexRunning);

            if (!mutexRunning)
            {
                MessageBox.Show("AltV Hotkey Reconnect is already running!", "AltV Hotkey Reconnect");
                Application.Exit();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            GC.KeepAlive(mutex);
        }
    }
}
