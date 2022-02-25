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

namespace Contact_Tracking
{
    public class Loops
    {
        Loop loop;
        Thread loopThread;
        static string lastLogName = SQL.LogName();
        static string lastStatName = SQL.StatsName();

        public class Loop
        {
            public static string timestamp = "[" + DateTime.Now.ToString("T") + "]";
            public static bool processingChanges;
            public static bool updatesFound;
            public static bool installPopUp;
            public event EventHandler<Changes> LoopUpdate;

            public void Update(Changes e)
            {
                if (LoopUpdate != null)
                {
                    LoopUpdate(this, e);
                }
            }
            
            public void Run()
            {
                timestamp = "[" + DateTime.Now.ToString("T") + "]";

                while (G.running)
                {
                    if (GitHub.CheckForUpdates())
                    {
                        updatesFound = true;
                    }

                    bool logSplit = false;
                    bool statSplit = false;

                    if (Properties.Settings.Default.SplitLog)
                    {
                        string logname = SQL.LogName();
                        if (logname  != lastLogName)
                        {
                            lastLogName = logname;
                            logSplit = true;
                        }
                    }

                    if (Properties.Settings.Default.SplitLog)
                    {
                        string statName = SQL.StatsName();
                        if (statName != lastStatName)
                        {
                            lastStatName = statName;
                            statSplit = true;
                        }
                    }

                    if (updatesFound || statSplit || logSplit || (!GitHub.UI_Updated && Main.initialized))
                    {
                        Update(new Changes(logSplit, updatesFound || !GitHub.UI_Updated, statSplit));
                    }
                }

                if (!G.running)
                {
                    ConsoleEx.WriteLine("Not Running but ticking!");
                }

                Thread.Sleep(250);
            }
        }
        public class Changes : EventArgs
        {
            public bool updatesFound;
            public bool installPopUp;
            public bool LogSplit;
            public bool StatSplit;

            public Changes(bool logSplit, bool updatestatus = false, bool statSplit = false)
            {
                LogSplit = logSplit;
                updatesFound = updatestatus;
                StatSplit = statSplit;
            }
        }
        public class ServerUpdate
        {

        }
        private void OnChange(object sender, Changes e)
        {
            if (MyControls.Main.InvokeRequired)
            {
                MyControls.Main.BeginInvoke((MethodInvoker)delegate
                {
                    OnChange(sender, e);
                });
                return;
            }

            if (e.StatSplit)
            {
                ConsoleEx.WriteLine("Passed the stat split time! Stat Split!");
                SQL.busy = true;

                bool exists = false;
                foreach (Stat stat in G.Stats)
                {
                    if (stat.Name == lastStatName)
                    {
                        G.CurrentStat = stat;
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    G.LastStatID++;
                    G.CurrentStat = new Stat();
                    var date = G.CurrentStat.Date;
                    G.CurrentStat.ID = G.LastStatID;
                    G.CurrentStat.Add();
                }
            }

            if (e.LogSplit)
            {
                ConsoleEx.WriteLine("Passed the log split time! Log Split!");
                SQL.busy = true;
                MyControls.TrackingTab.Log_Label.Text = "Log No. " + lastLogName[lastLogName.Length - 1];
                MyControls.TrackingTab.DateLabel.Text = DateTime.Now.ToString("D");

                foreach (Person p in G.People)
                {
                    p.visitorItem = null;
                    p.VisitTime = null;
                }

                MyControls.TrackingTab.VisitorList.Controls.Clear();
                if (!SQL.CreateLogsTable())
                {
                    SQL.ReadLog();
                }
            }

            if (e.updatesFound)
            {
                GitHub.UpdateUI();
            }

            SQL.busy = false;
        }

        public void InitializeLoop()
        {
            loop = new Loop();
            loop.LoopUpdate += new EventHandler<Changes>(OnChange);
            loopThread = new Thread(new ThreadStart(loop.Run));
            loopThread.Start();
        }
    }
}