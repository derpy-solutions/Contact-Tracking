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
    public class Fonts
    {
        public static bool setFonts = false;
        public static bool IsFontInstalled(string fontName)
        {
            using (var testFont = new System.Drawing.Font(fontName, 8))
                return 0 == string.Compare(fontName, testFont.Name, StringComparison.InvariantCultureIgnoreCase);
        }

        public static void InstallFont(string fontSourcePath)
        {
            //var shellAppType = Type.GetTypeFromProgID("Shell.Application");
            //var shell = Activator.CreateInstance(shellAppType);
            //var fontFolder = (Shell32.Folder)shellAppType.InvokeMember("NameSpace", System.Reflection.BindingFlags.InvokeMethod, null, shell, new object[] { Environment.GetFolderPath(Environment.SpecialFolder.Fonts) });
            var fontFolder = Environment.SpecialFolder.Fonts;
            if (File.Exists(fontSourcePath))
                File.Copy(fontSourcePath, fontFolder + Path.GetFileName(fontSourcePath), true);
        }

        public static string fallBackFont = "Arial";
        public static PrivateFontCollection privateFontCollection()
        {
            if (Properties.Settings.Default.DataPath != null && File.Exists(Properties.Settings.Default.DataPath + @"\Century Gothic Fat.ttf"))
            {
                var pfc = new PrivateFontCollection();
                pfc.AddFontFile(Properties.Settings.Default.DataPath + @"\Century Gothic Fat.ttf");
                return pfc;
            }
            else
            {
                var pfc = new PrivateFontCollection();
                return pfc;
            }
        }
        public static Font Header()
        {
            PrivateFontCollection pfc = privateFontCollection();

            if (pfc.Families.Length >= 1)
            {
                return new Font(pfc.Families[0], 18F, FontStyle.Regular, GraphicsUnit.Point);
            }
            else
            {
                return new Font(fallBackFont, 18F, FontStyle.Regular, GraphicsUnit.Point);
            }
        }
        public static Font MenuButton()
        {
            PrivateFontCollection pfc = privateFontCollection();
            if (pfc.Families.Length >= 1)
            {
                return new Font(pfc.Families[0], 14F, FontStyle.Regular, GraphicsUnit.Point);
            }
            else
            {
                return new Font(fallBackFont, 14F, FontStyle.Regular, GraphicsUnit.Point);
            }
        }
        public static Font Button()
        {
            PrivateFontCollection pfc = privateFontCollection();
            if (pfc.Families.Length >= 1)
            {
                return new Font(pfc.Families[0], 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            }
            else
            {
                return new Font(fallBackFont, 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            }
        }
        public static Font Text()
        {
            PrivateFontCollection pfc = privateFontCollection();
            if (pfc.Families.Length >= 1)
            {
                return new Font(pfc.Families[0], 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            }
            else
            {
                return new Font(fallBackFont, 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            }
        }
        public static Font TextItalic()
        {
            PrivateFontCollection pfc = privateFontCollection();
            if (pfc.Families.Length >= 1)
            {
                return new Font(pfc.Families[0], 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            }
            else
            {
                return new Font(fallBackFont, 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            }
        }
    }
}