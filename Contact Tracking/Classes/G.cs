using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Text;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Contact_Tracking
{
    public class G
    {
        public static int LastID = 1;
        public static int LastStatID = 1;
        public static List<Person> People = new List<Person>();
        public static List<Stat> Stats = new List<Stat>();
        public static Stat CurrentStat;

        public static int Years(DateTime start, DateTime end)
        {
            return (end.Year - start.Year - 1) +
                (((end.Month > start.Month) ||
                ((end.Month == start.Month) && (end.Day >= start.Day))) ? 1 : 0);
        }




        public static bool ProcessExists(int id)
        {
            return Process.GetProcesses().Any(x => x.Id == id);
        }
        public static List<Color> GetGradients(Color start, Color end, int steps)
        {
            List<Color> colors = new List<Color>();
            int stepA = ((end.A - start.A) / (steps - 1));
            int stepR = ((end.R - start.R) / (steps - 1));
            int stepG = ((end.G - start.G) / (steps - 1));
            int stepB = ((end.B - start.B) / (steps - 1));

            for (int i = 0; i < steps; i++)
            {
                colors.Add(Color.FromArgb(start.A + (stepA * i),
                                            start.R + (stepR * i),
                                            start.G + (stepG * i),
                                            start.B + (stepB * i)));
            }

            return colors;
        }

        public static string Language = "EN";
        public static List<string> ServerFoldersList = new List<string>();
        public static string[] ServerFolders;
        public static bool running = true;
        public static Control CardPanel;
        public static ListBox serverList;
        public static Font defaultHeaderFont;
        public static Font defaultSubHeaderFont;
        public static Font defaultTextFont;
        public static Font defaultButtonFont;
        public static Form Favorites { get; set; }
        public static FlowLayoutPanel favoritesPanel;

        public class Ver
        {
            public static Version current { get; set; }
            public static Version newest { get; set; }
            public static string url;
        }
    }
    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }
    }
}
