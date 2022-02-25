using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace Contact_Tracking.Custom_Controls
{
    public partial class RestartPopUp : UserControl
    {
        public string type = "Restart";
        public RestartPopUp()
        {
            InitializeComponent();


            Content.Text = Properties.strings.InstalledFonts;
            NoRestart.Text = Properties.strings.NoRestart;
            Restart.Text = Properties.strings.Restart;
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            switch (type)
            {
                case "Download":
                    WebClient client = new WebClient();
                    Uri uri = new Uri(G.Ver.url);

                    if (G.Ver.url != null && !File.Exists(Properties.Settings.Default.DataPath + @"\" + G.Ver.newest.ToString() + " Contact.Tracking.Setup.msi"))
                    {
                        MyControls.SideBar.DownloadProgress.Show();
                        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(MyControls.SideBar.DownloadProgressCallback4);
                        client.DownloadFileAsync(uri, Properties.Settings.Default.DataPath + @"\" + G.Ver.newest.ToString() + " Contact.Tracking.Setup.msi");
                    }
                    this.Hide();
                    break;

                case "Install":
                    if (GitHub.setupPID <= 0)
                    {
                        Process process = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe");
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
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
                    this.Hide();
                    break;

                case "Restart":
                    var path = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);

                    if (Directory.Exists(path) && Directory.Exists(path + @"\Programs"))
                    {
                        path = path + @"\Programs";

                        ConsoleEx.WriteLine("Startup Folder Exists.");
                        ConsoleEx.WriteLine(path);
                        ConsoleEx.WriteLine(path + @"\Contact Tracking.lnk");
                        if (File.Exists(path + @"\Contact Tracking.lnk"))
                        {

                            ConsoleEx.WriteLine("Shortcut Exists.");

                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe");
                            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                            startInfo.UseShellExecute = true;
                            startInfo.CreateNoWindow = true;
                            startInfo.Arguments = "/C " + '"' + path + @"\Contact Tracking.lnk" + '"';
                            startInfo.WorkingDirectory = Properties.Settings.Default.DataPath;
                            process.StartInfo = startInfo;
                            if (process.Start())
                            {
                                Application.Exit();
                            }
                        }
                    }
                    this.Hide();

                    break;
            }
        }

        private void NoRestart_Click(object sender, EventArgs e)
        {
            switch (type)
            {
                case "Download":
                    GitHub.dismissUpdate = true;
                    break;

                case "Install":
                    GitHub.dismissUpdate = true;
                    break;

                case "Restart":
                    break;
            }

            this.Hide();
        }
    }
}
