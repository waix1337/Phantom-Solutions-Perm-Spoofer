using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhantomSolutions.Tasks
{
    internal class Run
    {
        public static void CMD(string cmd, bool showoutput = false)
        {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/c " + cmd; // /c means execute the command and then terminate
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                if (showoutput)
                {
                     Console.WriteLine(output);
                }
                process.WaitForExit();
        }
        public static void resetwinmgmt()
        {
            CMD("net stop winmgmt /y && net start winmgmt /y && sc stop winmgmt && sc start winmgmt");
        }
        public static void runpdrv()
        {
            CMD(@"C:\PhantomSolutions\zhjers.exe /SU auto");
            CMD(@"C:\PhantomSolutions\zhjers.exe /SS ""Default string""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /SV ""1.0""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /CSK ""Default string""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /CM  ""Default string""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /SP ""MS-7D22""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /SM ""Micro-Star International Co., Ltd.""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /SK ""Default string""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /SF ""Default string""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /BM ""Micro-Star International Co., Ltd.""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /BP ""H510M-A PRO (MS-7D22)""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /BV ""1.0""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /BT ""Default string""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /BLC ""Default string""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /PSN ""To Be Filled By O.E.M.""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /PAT ""To Be Filled By O.E.M.""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /PPN ""To Be Filled By O.E.M.""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /CSK ""Default string""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /CS ""Default string""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /CV ""1.0""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /CM ""Micro-Star International Co., Ltd.""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /CA ""Default string""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /CO ""0000 0000h""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /CT ""03h""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /IV ""3.80""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /IVN ""American Megatrends International, LLC.""");
            CMD(@"C:\PhantomSolutions\zhjers.exe /BS ""%random%%random%%random%%random%%random%""");
        }
    }
}
