using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PhantomSolutions.Other
{
    internal class Natives
    {
        [DllImport("user32.dll")]
        public static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
        [DllImport("user32.dll")]
        public static extern bool BlockInput(bool fkk);
        public static IntPtr currenthandle()
        {
            return Process.GetCurrentProcess().MainWindowHandle;
        }
        public static void GetWMICProperty(string className, string propertyName)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM " + className); foreach (ManagementObject obj in searcher.Get()) { Console.WriteLine(obj[propertyName]); }
        }
    }
}
