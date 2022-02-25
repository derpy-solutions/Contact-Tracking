using System;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;


namespace Contact_Tracking
{
    class GitHub
    {
        public static DateTime UpdateCheckTime { get; set; }
        public static DateTime ui_updated { get; set; }
        public static bool hasInternet;
        public static bool dismissUpdate;
        public static bool updateAvailable;
        public static Version current;
        public static Version newest;
        public static bool UI_Updated;
        public static int setupPID;

        public static void UpdateUI()
        {
            if (ui_updated != UpdateCheckTime || !UI_Updated)
            {
                if (hasInternet && updateAvailable)
                {
                    MyControls.SideBar.UpdateNotification.Image = Properties.Resources.circle_exclamationmark_red;
                    MyControls.SideBar.NewestVersion.Text = newest.ToString();
                    MyControls.SideBar.CurrentVersion.Text = current.ToString();
                    MyControls.SideBar.UpdateButton.Show();

                    if (Properties.Settings.Default.ShowTooltips)
                    {
                        MyControls.Main.toolTip1.SetToolTip(MyControls.SideBar.UpdateNotification, Properties.strings.ttp_UpdateAvailable);
                    }

                    if (File.Exists(Properties.Settings.Default.DataPath + @"\" + G.Ver.newest.ToString() + " Contact.Tracking.Setup.msi"))
                    {
                        MyControls.SideBar.UpdateButton.Text = "         " + Properties.strings.Install + " Update";
                        MyControls.SideBar.UpdateButton.Image = Properties.Resources.unbox;

                        if (!dismissUpdate)
                        {
                            MyControls.Main.restartPopUp.type = "Install";
                            MyControls.Main.restartPopUp.Content.Text = Properties.strings.UpdateInstall;
                            MyControls.Main.restartPopUp.Restart.Text = Properties.strings.Yes;
                            MyControls.Main.restartPopUp.NoRestart.Text = Properties.strings.No;
                            MyControls.Main.restartPopUp.Show();
                        }
                    }
                    else
                    {
                        if (!dismissUpdate)
                        {
                            MyControls.Main.restartPopUp.type = "Download";
                            MyControls.Main.restartPopUp.Content.Text = Properties.strings.UpdatePopUp;
                            MyControls.Main.restartPopUp.Restart.Text = Properties.strings.Yes;
                            MyControls.Main.restartPopUp.NoRestart.Text = Properties.strings.No;
                            MyControls.Main.restartPopUp.Show();
                        }
                    }
                }
                else
                {
                    if (hasInternet)
                    {
                        MyControls.SideBar.UpdateNotification.Image = Properties.Resources.circle_checkmark_green;
                    }
                    else
                    {
                        MyControls.SideBar.UpdateNotification.Image = Properties.Resources.no_internet;

                        if (Properties.Settings.Default.ShowTooltips)
                        {
                            MyControls.Main.toolTip1.SetToolTip(MyControls.SideBar.UpdateNotification, Properties.strings.ttp_NoInternet);
                        }
                    }


                    if (newest != null)
                    {
                        MyControls.SideBar.NewestVersion.Text = newest.ToString();
                    }
                    else
                    {
                        MyControls.SideBar.NewestVersion.Text = "N/A";
                    }

                    if (current != null)
                    {
                        MyControls.SideBar.CurrentVersion.Text = current.ToString();
                    }
                    else
                    {
                        System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                        System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
                        string version = fvi.FileVersion;
                        ConsoleEx.WriteLine(version);
                        current = Version.Parse(version);

                        MyControls.SideBar.CurrentVersion.Text = current.ToString();
                    }
                }

                UI_Updated = true;
                ui_updated = UpdateCheckTime;
            }
        }

        public static bool CheckForUpdates(bool force = false)
        {
            if (Properties.Settings.Default.CheckForUpdates)
            {
                if (force || DateTime.Now.Subtract(UpdateCheckTime).TotalMinutes >= 60)
                {
                    ConsoleEx.WriteLine("Time Since Update: " + DateTime.Now.Subtract(UpdateCheckTime).TotalMinutes);
                    UpdateCheckTime = DateTime.Now;
                    hasInternet = HasInternetConnection(2500);

                    if (hasInternet)
                    {
                        if (UpdateAvailable())
                        {
                            updateAvailable = true;
                            return true;
                        }
                    }
                    else
                    {
                        newest = null;
                        G.Ver.newest = null;
                        UpdateCheckTime = DateTime.Now.AddMinutes(-45);
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool IsInternetConnected()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool HasInternetConnection(int timeoutMs = 10000, string url = null)
        {
            try
            {
                url = "http://google.com/generate_204";

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.KeepAlive = false;
                request.Timeout = timeoutMs;
                using (var response = (HttpWebResponse)request.GetResponse())
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool UpdateAvailable()
        {
            string GetReleases(string username, string repoName)
            {
                const string GITHUB_API = "https://api.github.com/repos/{0}/{1}/releases";
                WebClient webClient = new WebClient();
                // Added user agent
                webClient.Headers.Add("User-Agent", "Unity web player");
                Uri uri = new Uri(string.Format(GITHUB_API, username, repoName));
                string current_releases = webClient.DownloadString(uri);

                return current_releases;
            }

            var str = GetReleases("derpy-solutions", "Contact-Tracking");

            var releases = JsonConvert.DeserializeObject<List<Root>>(str);

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            G.Ver.current = Version.Parse(version);
            var update = false;
            var url = "";

            foreach (Root release in releases)
            {
                Version ver = null;

                if (Version.TryParse(release.tag_name, out ver))
                {
                    if (G.Ver.newest == null || ver > G.Ver.newest)
                    {
                        G.Ver.newest = ver;
                        Asset assest = release.assets[0];
                        url = assest.browser_download_url;

                        if (ver > Version.Parse(version))
                        {
                            update = true;
                        }
                    }
                }
            }

            if (G.Ver.newest == null)
            {
                G.Ver.newest = G.Ver.current;
            }

            newest = G.Ver.newest;
            current = G.Ver.current;

            if (update)
            {
                ConsoleEx.WriteLine("There is an update available!", ConsoleColor.Green);
                G.Ver.url = url;
                return true;
            }
            ConsoleEx.WriteLine("You are currently using the newest version!", ConsoleColor.Green);
            return false;
        }        
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Author
    {
        public string login { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public bool site_admin { get; set; }
    }
    public class Uploader
    {
        public string login { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public bool site_admin { get; set; }
    }
    public class Asset
    {
        public string url { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public string name { get; set; }
        public object label { get; set; }
        public Uploader uploader { get; set; }
        public string content_type { get; set; }
        public string state { get; set; }
        public int size { get; set; }
        public int download_count { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string browser_download_url { get; set; }
    }
    public class Root
    {
        public string url { get; set; }
        public string assets_url { get; set; }
        public string upload_url { get; set; }
        public string html_url { get; set; }
        public int id { get; set; }
        public Author author { get; set; }
        public string node_id { get; set; }
        public string tag_name { get; set; }
        public string target_commitish { get; set; }
        public string name { get; set; }
        public bool draft { get; set; }
        public bool prerelease { get; set; }
        public DateTime created_at { get; set; }
        public DateTime published_at { get; set; }
        public List<Asset> assets { get; set; }
        public string tarball_url { get; set; }
        public string zipball_url { get; set; }
        public string body { get; set; }
    }
}
