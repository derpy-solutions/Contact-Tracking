using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;
using System.Drawing;
using System.Globalization;

namespace Contact_Tracking
{
    public partial class Main : Form
    {
        public static System.Resources.ResourceManager rm = new System.Resources.ResourceManager("Contact_Tracking.de_local", Assembly.GetExecutingAssembly());
        //public static CultureInfo culture = new CultureInfo("en-US");

        public static bool initialized;
        public Main()
        {
            switch (Properties.Settings.Default.Language)
            {
                case "EN":
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
                    break;

                case "DE":
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
                    break;
            }

            Console.WriteLine("Main Tick - Init");

            if (Properties.Settings.Default.DataPath.ToString() == "" || Properties.Settings.Default.ServerPath.ToString() == "")
            {
                Properties.Settings.Default.ServerPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Minecraft Server Manager";
                Properties.Settings.Default.DataPath = @"C:\Program Files\derpy Solutions\Minecraft Server Manager\Data";
                Properties.Settings.Default.Save();
            }

            Directory.CreateDirectory(Properties.Settings.Default.ServerPath);
            Directory.CreateDirectory(Properties.Settings.Default.DataPath);


            InitializeComponent();
            MyControls.Main = this;
            MyControls.SideBar = SideBar;
            MyControls.TrackingTab = tracking;
            MyControls.PersonTab = personCard;
            MyControls.Stats = statistics_Tab;


            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            Console.WriteLine(version);
            G.Ver.current = Version.Parse(version);

            MyControls.SideBar.CurrentVersion.Text = G.Ver.current.ToString();

            Loops loops = new Loops();
            loops.InitializeLoop();

            foreach (Action action in Inits.Voids)
            {
                action();
            }

            Fonts.InstallFont(Properties.Settings.Default.DataPath + @"\Fonts\CenturyGothic_Bold.ttf");

            if (!Fonts.IsFontInstalled("Century Gothic"))
            {
                Fonts.InstallFont(Properties.Settings.Default.DataPath + @"\Fonts\CenturyGothic_Bold.ttf");
                Fonts.InstallFont(Properties.Settings.Default.DataPath + @"\Fonts\CenturyGothic_Bold_Italic.ttf");
                Fonts.InstallFont(Properties.Settings.Default.DataPath + @"\Fonts\CenturyGothic_Italic.ttf");
                Fonts.InstallFont(Properties.Settings.Default.DataPath + @"\Fonts\CenturyGothic_Regular.ttf");

                var path = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);
            }

            Initialize();
            initialized = true;
            SQL.Run();
        }

        private List<string> getIniFiles(int category = 1)
        {
            string[] fileArray = { };
            switch (category)
            {
                case 1:
                    {
                        fileArray = Directory.GetFiles(Properties.Settings.Default.DataPath.ToString() + @"\Status Updates", "*.ini");
                        break;
                    }
                case 2:
                    {
                        fileArray = Directory.GetFiles(Properties.Settings.Default.DataPath + @"\Status Updates\update", "*.ini");
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            List<string> files = fileArray.ToList();
            return files;
        }

        public void Initialize()
        {
            Console.WriteLine("[" + DateTime.Now + "]: " + "Initialize...");
        }

        private void Main_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                Console.WriteLine("Store Pos and Size");
                // save location and size if the state is normal
                Properties.Settings.Default.Position = this.Location;
                Properties.Settings.Default.Size = this.Size;
            }
            else
            {
                Console.WriteLine("Store Restore Pos and Size");
                // save the RestoreBounds if the form is minimized or maximized!
                Properties.Settings.Default.Position = this.RestoreBounds.Location;
                Properties.Settings.Default.Size = this.RestoreBounds.Size;            }

            Properties.Settings.Default.Save();

            G.running = false;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.FormClosing += Main_FormClosing;
            this.Location = Properties.Settings.Default.Position;
            this.Size = Properties.Settings.Default.Size;
        }

        private void Main_MouseClick(object sender, MouseEventArgs e)
        {
            if (SideBar.Width >= SideBar.MaximumSize.Width)
            {
                SideBar.SideBarTimer.Start();
            }
        }

        private void restartPopUp_VisibleChanged(object sender, EventArgs e)
        {
            if (restartPopUp.Visible)
            {
                int x = (this.Width - restartPopUp.Width) / 2;
                int y = (this.Height - restartPopUp.Height) / 2;

                var pos = new Point(x,y);
                restartPopUp.Location = pos;
                restartPopUp.Update();
            }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (restartPopUp.Visible)
            {
                int x = (this.Width - restartPopUp.Width) / 2;
                int y = (this.Height - restartPopUp.Height) / 2;

                var pos = new Point(x, y);
                restartPopUp.Location = pos;
                restartPopUp.Update();
            }
        }

        private void Main_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            this.tracking.qrCodeReader.StopQR();
            G.running = false;
        }
    }
}