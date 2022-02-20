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

            SideBar_Menu.Text = "         " + Main.rm.GetString("Menu");
            SideBar_Tracking.Text = "         " + Main.rm.GetString("Tracking");
            SideBar_Settings.Text = "         " + Main.rm.GetString("Settings");
            UpdateButton.Text = "         " + Main.rm.GetString("Update");
            CurrentLabel.Text = Main.rm.GetString("Current") + ":";
            NewestLabel.Text = Main.rm.GetString("Newest") + ":";

            Inits.Voids.Add(Init);
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
            if (this.Width >= this.MaximumSize.Width)
            {
                sidebarExpand = true;
                SideBarTimer.Start();
            }

            var tracking = this.ParentForm.Controls["tracking"];
            tracking.Show();

            var personCard = this.ParentForm.Controls["personCard"];
            personCard.Hide();

            var settings = this.ParentForm.Controls["settings"];
            settings.Hide();
            //       this.Parent.Controls[""]
        }

        private void SideBar_Settings_Click(object sender, EventArgs e)
        {
            if (this.Width >= this.MaximumSize.Width)
            {
                sidebarExpand = true;
                SideBarTimer.Start();
            }

            var tracking = this.ParentForm.Controls["tracking"];
            tracking.Hide();

            var personCard = this.ParentForm.Controls["personCard"];
            personCard.Hide();

            var settings = this.ParentForm.Controls["settings"];
            settings.Show();
        }
        public void DownloadProgressCallback4(object sender, DownloadProgressChangedEventArgs e)
        {
            // Displays the operation identifier, and the transfer progress.
            Console.WriteLine("{0}    downloaded {1} of {2} bytes. {3} % complete...",
                (string)e.UserState,
                e.BytesReceived,
                e.TotalBytesToReceive,
                e.ProgressPercentage);

            MyControls.SideBar.DownloadProgress.Value = e.ProgressPercentage;

            if (e.ProgressPercentage == 100)
            {
                MyControls.SideBar.DownloadProgress.Hide();
                MyControls.SideBar.UpdateButton.Text = "         " + Main.rm.GetString("Install")  + " Update";
                MyControls.SideBar.UpdateButton.Image = Properties.Resources.unbox;


                MyControls.Main.restartPopUp.type = "Install";
                MyControls.Main.restartPopUp.Content.Text = Main.rm.GetString("DownloadComplete");
                MyControls.Main.restartPopUp.Restart.Text = Main.rm.GetString("Yes");
                MyControls.Main.restartPopUp.NoRestart.Text = Main.rm.GetString("No");
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
            if (this.Width >= this.MaximumSize.Width)
            {
                sidebarExpand = true;
                SideBarTimer.Start();
            }
            var tracking = this.ParentForm.Controls["tracking"];
            tracking.Hide();

            var personCard = MyControls.PersonTab;

            if (personCard.person == null)
            {
                Person person = new Person();
                person.ID = G.LastID + 1;
                personCard.person = person;
                person.LoadCard();
            }
            personCard.Show();

            var settings = this.ParentForm.Controls["settings"];
            settings.Hide();
        }
    }
}
