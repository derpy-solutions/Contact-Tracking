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

        public class Loop
        {
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
                while (G.running)
                {
                   
                    Thread.Sleep(250);
                }

                if (!G.running)
                {
                    Console.WriteLine("Not Running but ticking!");
                }
            }
        }
        public class Changes : EventArgs
        {
            public bool updatesFound;
            public bool installPopUp;
            public List<ServerUpdate> Servers { get; set; }

            public Changes(List<ServerUpdate> servers = null, bool updatestatus = false, bool installpop = false)
            {
                Servers = servers;
                updatesFound = updatestatus;
                installPopUp = installpop;
            }
        }
        public class ServerUpdate
        {

        }
        private void OnChange(object sender, Changes e)
        {
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