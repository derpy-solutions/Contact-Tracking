using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Text;
using System.Xml;
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
    }
    public class Inits
    {
       public static List<Action> Voids = new List<Action>();  
    }
}