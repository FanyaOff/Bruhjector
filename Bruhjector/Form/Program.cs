using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Media;
using Dashboard.Properties;
using System.Threading;

namespace Dashboard
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // kill steam
            foreach (var process in Process.GetProcessesByName("steam.exe")) 
            {
                process.Kill();
            }

            // wait some time
            Thread.Sleep(100);

            // vac bypass
            string temp = Path.GetTempPath();
            string file_exe = Path.GetTempPath() + "\\vac.exe";
            FileStream fs = new FileStream(file_exe, FileMode.Create);
            fs.Write(Resources.vac, 0, Resources.vac.Length);
            fs.Close();
            Process.Start(file_exe);

            // main form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Bruhjector());

        }
    }
}
