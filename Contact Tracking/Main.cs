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
using System.Security.Cryptography;

namespace Contact_Tracking
{
    public partial class Main : Form
    {
        public DateTime _Date;
        public static bool initialized;
        public Main()
        {
            EnsureSettings();

            Directory.CreateDirectory(Properties.Settings.Default.DataPath);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);

            InitializeComponent();
            MyControls.Main = this;
            MyControls.SideBar = SideBar;
            MyControls.TrackingTab = tracking;
            MyControls.PersonTab = personCard;
            MyControls.Stats = statistics_Tab;
            MyControls.SettingsTab = settings;
            MyControls.SideBar.CurrentVersion.Text = G.Ver.current.ToString();

            Loops loops = new Loops();
            loops.InitializeLoop();

            foreach (Action action in Inits.Voids)
            {
                action();
            }

            Initialize();
            SQL.Run();

            initialized = true;

            Language.Load();
        }

        public void Initialize()
        {
            ConsoleEx.WriteLine("Initialize ...");
        }

        public void EnsureSettings()
        {
            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.Save();
            }

            if (Properties.Settings.Default.DataPath == null || Properties.Settings.Default.DataPath == "")
            {
                Properties.Settings.Default.DataPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Contact Tracking";
                Properties.Settings.Default.Save();
            }
            
            if (Properties.Settings.Default.Language == null)
            {
                switch (CultureInfo.CurrentCulture.Name)
                {
                    case "en-US":
                        Properties.Settings.Default.Language = "en-US";
                        break;

                    case "de-DE":
                        Properties.Settings.Default.Language = "de-DE";
                        break;

                    default:
                        Properties.Settings.Default.Language = "en-US";
                        break;
                }
            }

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            ConsoleEx.WriteLine("Starting Contact Tracking v." + version, ConsoleColor.Red);

            G.Ver.current = Version.Parse(version);

            if (Properties.Settings.Default.InstalledVersion != version || !Fonts.IsFontInstalled("Century Gothic"))
            {
                ConsoleEx.WriteLine("Installing fonts ...", ConsoleColor.Yellow);
                Fonts.InstallFont(Application.StartupPath + @"\Data" + @"\Fonts\CenturyGothic_Bold.ttf");
                Fonts.InstallFont(Application.StartupPath + @"\Data" + @"\Fonts\CenturyGothic_Bold_Italic.ttf");
                Fonts.InstallFont(Application.StartupPath + @"\Data" + @"\Fonts\CenturyGothic_Italic.ttf");
                Fonts.InstallFont(Application.StartupPath + @"\Data" + @"\Fonts\CenturyGothic_Regular.ttf");
                Properties.Settings.Default.InstalledVersion = version;
                Properties.Settings.Default.Save();
            }

            if (Properties.Settings.Default.SecurityKey == null || Properties.Settings.Default.SecurityIV == null || Properties.Settings.Default.SecurityIV == "" || Properties.Settings.Default.SecurityKey == "")
            {
                Aes aes = Aes.Create();

                Properties.Settings.Default.SecurityKey = Convert.ToBase64String(aes.Key);
                Properties.Settings.Default.SecurityIV = Convert.ToBase64String(aes.IV);
                Properties.Settings.Default.Save();
            }
        }

        private void Main_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                ConsoleEx.WriteLine("Store Pos and Size", ConsoleColor.Green);
                // save location and size if the state is normal
                Properties.Settings.Default.Position = this.Location;
                Properties.Settings.Default.Size = this.Size;
            }
            else
            {
                ConsoleEx.WriteLine("Store Restore Pos and Size", ConsoleColor.Green);
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