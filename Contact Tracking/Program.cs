using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace Contact_Tracking
{
    static class Program
    {
        [DllImport("kernel32.dll", EntryPoint = "GetStdHandle", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int AllocConsole();

        private const int STD_OUTPUT_HANDLE = -11;
        private const int MY_CODE_PAGE = 437;

        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    switch (args[i])
                    {
                        case "-console":
                            {
                                AllocConsole();
                                IntPtr stdHandle = GetStdHandle(STD_OUTPUT_HANDLE);
                                Microsoft.Win32.SafeHandles.SafeFileHandle safeFileHandle = new Microsoft.Win32.SafeHandles.SafeFileHandle(stdHandle, true);
                                FileStream fileStream = new FileStream(safeFileHandle, FileAccess.Write);
                                System.Text.Encoding encoding = System.Text.Encoding.GetEncoding(MY_CODE_PAGE);
                                StreamWriter standardOutput = new StreamWriter(fileStream, encoding);
                                standardOutput.AutoFlush = true;
                                Console.SetOut(standardOutput);
                                break;
                            }
                    }
                }
            }

            for (int i = 0; i < args.Length; i++)
            {
                ConsoleEx.WriteLine(args[i].ToString());
            }

            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}