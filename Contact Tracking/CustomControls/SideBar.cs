using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Net;

namespace Contact_Tracking.Custom_Controls
{
    public partial class SideBar : UserControl
    {
        public bool sidebarExpand;

        public SideBar()
        {
            InitializeComponent();

            Inits.Voids.Add(Init);
            Language.Actions.Add(new Language.Entry() { action = LoadLanguage, name = "SideBar", initialized = true });


        }

        public void LoadLanguage()
        {
            SideBar_Menu.Text = "         " + Properties.strings.Menu;
            SideBar_Tracking.Text = "         " + Properties.strings.Tracking;
            SideBar_Settings.Text = "         " + Properties.strings.Settings;
            UpdateButton.Text = "         " + Properties.strings.Update;
            Stats_Button.Text = "         " + Properties.strings.Statistics;
            SideBar_Create.Text = "         " + Properties.strings.Create;
            CurrentLabel.Text = Properties.strings.Current + ":";
            NewestLabel.Text = Properties.strings.Newest + ":";
        }

        public class TabButton
        {
            public Control tab;
            public Button button;
        }

        public void SwitchTab(Button button)
        {
            List<TabButton> tabs = new List<TabButton>();
            tabs.Add( new TabButton() { tab = MyControls.TrackingTab, button = SideBar_Tracking });
            tabs.Add(new TabButton() { tab = MyControls.PersonTab, button = SideBar_Create });
            tabs.Add(new TabButton() { tab = MyControls.Stats, button = Stats_Button });
            tabs.Add(new TabButton() { tab = MyControls.SettingsTab, button = SideBar_Settings });

            foreach (TabButton tabButton in tabs)
            {
                if (tabButton.button != button)
                {
                    tabButton.button.BackColor = Color.Transparent;
                    tabButton.tab.Hide();
                }
                else
                {
                    tabButton.button.BackColor = Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
                    tabButton.tab.Show();
                }
            }

            if (this.Width >= this.MaximumSize.Width)
            {
                sidebarExpand = true;
                SideBarTimer.Start();
            }
            CurrentLabel.Focus();
        }

        public void Init()
        {
        }

        private void SideBarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                this.Width -= 10;

                if (this.Width <= this.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    SideBarTimer.Stop();
                }
            }
            else
            {
                this.Width += 10;
                if (this.Width >= this.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    SideBarTimer.Stop();
                }

            }
        }

        private void SideBar_Menu_Click(object sender, EventArgs e)
        {

            SideBarTimer.Start();
        }

        private void SideBar_Servers_Click(object sender, EventArgs e)
        {
            SwitchTab(SideBar_Tracking);
        }

        private void SideBar_Settings_Click(object sender, EventArgs e)
        {
            SwitchTab(SideBar_Settings);
        }
        public void DownloadProgressCallback4(object sender, DownloadProgressChangedEventArgs e)
        {
            // Displays the operation identifier, and the transfer progress.
            string progress = $"{e.UserState}    downloaded {e.BytesReceived} of {e.TotalBytesToReceive} bytes. {e.ProgressPercentage} % complete...";
            ConsoleEx.WriteLine(progress);

            MyControls.SideBar.DownloadProgress.Value = e.ProgressPercentage;

            if (e.ProgressPercentage == 100)
            {
                MyControls.SideBar.DownloadProgress.Hide();
                MyControls.SideBar.UpdateButton.Text = "         " + Properties.strings.Install  + " Update";
                MyControls.SideBar.UpdateButton.Image = Properties.Resources.unbox;


                MyControls.Main.restartPopUp.type = "Install";
                MyControls.Main.restartPopUp.Content.Text = Properties.strings.DownloadComplete;
                MyControls.Main.restartPopUp.Restart.Text = Properties.strings.Yes;
                MyControls.Main.restartPopUp.NoRestart.Text = Properties.strings.No;
                MyControls.Main.restartPopUp.Show();
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            Uri uri = new Uri(G.Ver.url);

            if (G.Ver.url != null && !File.Exists(Properties.Settings.Default.DataPath + @"\" + G.Ver.newest.ToString() + " Contact.Tracking.Setup.msi"))
            {

                MyControls.SideBar.DownloadProgress.Show();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback4);
                client.DownloadFileAsync(uri, Properties.Settings.Default.DataPath + @"\" + G.Ver.newest.ToString() + " Contact.Tracking.Setup.msi");
            }
            else
            {
                if (GitHub.setupPID <= 0)
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe");
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.UseShellExecute = true;
                    startInfo.CreateNoWindow = true;
                    startInfo.Arguments = "/C " + '"' + G.Ver.newest.ToString() + " Contact.Tracking.Setup.msi" + '"';
                    startInfo.WorkingDirectory = Properties.Settings.Default.DataPath;
                    process.StartInfo = startInfo;
                    if (process.Start())
                    {
                        GitHub.setupPID = process.Id;
                        Application.Exit();
                    }
                }

                MyControls.SideBar.DownloadProgress.Hide();
                MyControls.SideBar.UpdateButton.Text = "         Install Update";
                MyControls.SideBar.UpdateButton.Image = Properties.Resources.unbox;
            }
        }

        private void CheckForUpdates_Click(object sender, EventArgs e)
        {

            GitHub.UpdateCheckTime = DateTime.Now.AddMinutes(-60);
            //GitHub.CheckForUpdates(true);
        }

        private void SideBar_Create_Click(object sender, EventArgs e)
        {
            var personCard = MyControls.PersonTab;

            if (personCard.person == null)
            {
                Person person = new Person();
                person.ID = G.LastID + 1;
                personCard.person = person;
                person.LoadCard();
            }

            SwitchTab(SideBar_Create);
        }

        private void Stats_Button_Click(object sender, EventArgs e)
        {
            SwitchTab(Stats_Button);
        }
    }
}
