using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Text;
using System.Xml;
using System.Threading;
using System.Globalization;
using System.Xml.Linq;

namespace Contact_Tracking
{
    public class MyControls
    {
        public static Main Main;
        public static Custom_Controls.SideBar SideBar;   
        public static Custom_Controls.TrackingTab TrackingTab;   
        public static Custom_Controls.PersonCard PersonTab;
        public static Custom_Controls.Statistics_Ctrl Stats;
        public static Custom_Controls.Settings SettingsTab;
    }
    public class Inits
    {
       public static List<Action> Voids = new List<Action>();  
    }
    
    public class Language
    {
        public class Entry
        {
            public string name;
            public bool initialized;
            public Action action;
        }
       public static List<Entry> Actions = new List<Entry>();
        public static void Load()
        { 
            ConsoleEx.WriteLine("Switching to Language pack: '" + Properties.Settings.Default.Language + "'");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);

            ConsoleEx.WriteLine(Thread.CurrentThread.CurrentUICulture.Name, ConsoleColor.Red);
            foreach (Entry entry in Actions)
            {
                if (entry.initialized)
                {
                    ConsoleEx.WriteLine("Switching Language in control: " + entry.name);
                    entry.action();
                }
                else
                {
                    ConsoleEx.WriteLine(entry.name + " is not initialized yet!");
                }
            }
        }
        public static void LoadOG()
        { 
            ConsoleEx.WriteLine("Switching to Language pack: '" + Properties.Settings.Default.Language + "'");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);

            //foreach (Action action in Actions)
            //{
            //    action();
            //}
        }
    }
}