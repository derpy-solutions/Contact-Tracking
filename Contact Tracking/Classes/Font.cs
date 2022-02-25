using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Text;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Contact_Tracking
{
    public class Fonts
    {
        [DllImport("gdi32.dll", EntryPoint = "AddFontResourceW", SetLastError = true)]
        public static extern int AddFontResource([In][MarshalAs(UnmanagedType.LPWStr)]
                                         string lpFileName);

        [DllImport("gdi32.dll", EntryPoint = "RemoveFontResourceW", SetLastError = true)]
        public static extern int RemoveFontResource([In][MarshalAs(UnmanagedType.LPWStr)]
                                            string lpFileName);

        public static bool setFonts = false;
        public static bool IsFontInstalled(string fontName)
        {
            using (var testFont = new System.Drawing.Font(fontName, 8))
                return 0 == string.Compare(fontName, testFont.Name, StringComparison.InvariantCultureIgnoreCase);
        }

        public static void InstallFont(string fontSourcePath)
        {
            int result = -1;
            int error = 0;

            //var shellAppType = Type.GetTypeFromProgID("Shell.Application");
            //var shell = Activator.CreateInstance(shellAppType);
            //var fontFolder = (Shell32.Folder)shellAppType.InvokeMember("NameSpace", System.Reflection.BindingFlags.InvokeMethod, null, shell, new object[] { Environment.GetFolderPath(Environment.SpecialFolder.Fonts) });
            //var fontFolder = Environment.SpecialFolder.Fonts;
            
            if (File.Exists(fontSourcePath))
            {
                //File.Copy(fontSourcePath, fontFolder + @"\" + Path.GetFileName(fontSourcePath), true);
                // Try install the font.
                result = AddFontResource(@fontSourcePath);
                error = Marshal.GetLastWin32Error();
                if (error != 0)
                {
                    ConsoleEx.WriteLine(new Win32Exception(error).Message);
                }
                else
                {
                    ConsoleEx.WriteLine((result == 0) ? "Font is already installed." :
                                                      "Font installed successfully.");
                }
            }
        }

        public static string fallBackFont = "Arial";
        public static PrivateFontCollection privateFontCollection()
        {
            if (Application.StartupPath + @"\Data" != null && File.Exists(Application.StartupPath + @"\Data" + @"\Century Gothic Fat.ttf"))
            {
                var pfc = new PrivateFontCollection();
                pfc.AddFontFile(Application.StartupPath + @"\Data" + @"\Century Gothic Fat.ttf");
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