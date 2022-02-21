using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Text;

namespace Contact_Tracking
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            Console.WriteLine("Main Tick - Program");
            if (Properties.Settings.Default.DataPath == null || Properties.Settings.Default.DataPath.ToString() == "")
            {
                Properties.Settings.Default.DataPath = @"C:\Program Files\derpy Solutions\Minecraft Server Manager\Data";
                Properties.Settings.Default.Save();
            }

            if (Properties.Settings.Default.ServerPath == null || Properties.Settings.Default.ServerPath.ToString() == "")
            {
                Properties.Settings.Default.ServerPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Minecraft Server Manager";
                Properties.Settings.Default.Save();
            }


            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}