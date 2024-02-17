using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using KeyAuth;
using System.Text;
using System.Threading.Tasks;

namespace PhantomSolutions
{
    internal class Program
    {
        public static api KeyAuthApp = new api(
    name: "phantom",
    ownerid: "7BYxMBBAPS",
    secret: "7664a396c27c13d2b4e5b0b5d37147a7c08dcf6cd1726d85bd387f04f93d4656",
    version: "1.0"
);
        static void Main(string[] args)
        {
            KeyAuthApp.init();
            Threads.index.init();
            Other.Natives.SetLayeredWindowAttributes(Other.Natives.currenthandle(), 0, 200, 2);
            Console.Title = "Phantom Solutions";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@" ██▓███   ██░ ██  ▄▄▄       ███▄    █ ▄▄▄█████▓ ▒█████   ███▄ ▄███▓
▓██░  ██▒▓██░ ██▒▒████▄     ██ ▀█   █ ▓  ██▒ ▓▒▒██▒  ██▒▓██▒▀█▀ ██▒
▓██░ ██▓▒▒██▀▀██░▒██  ▀█▄  ▓██  ▀█ ██▒▒ ▓██░ ▒░▒██░  ██▒▓██    ▓██░
▒██▄█▓▒ ▒░▓█ ░██ ░██▄▄▄▄██ ▓██▒  ▐▌██▒░ ▓██▓ ░ ▒██   ██░▒██    ▒██ 
▒██▒ ░  ░░▓█▒░██▓ ▓█   ▓██▒▒██░   ▓██░  ▒██▒ ░ ░ ████▓▒░▒██▒   ░██▒
▒▓▒░ ░  ░ ▒ ░░▒░▒ ▒▒   ▓▒█░░ ▒░   ▒ ▒   ▒ ░░   ░ ▒░▒░▒░ ░ ▒░   ░  ░
░▒ ░      ▒ ░▒░ ░  ▒   ▒▒ ░░ ░░   ░ ▒░    ░      ░ ▒ ▒░ ░  ░      ░
░░        ░  ░░ ░  ░   ▒      ░   ░ ░   ░      ░ ░ ░ ▒  ░      ░   
          ░  ░  ░      ░  ░         ░              ░ ░         ░   
                                                                   ");
            Console.Write("Enter license>");
            KeyAuthApp.license(Console.ReadLine());
            bool kekcrack = KeyAuthApp.response.success;
            if (!kekcrack)
            {
                Environment.Exit(-1);
            }
            if (!kekcrack)
            {
                Environment.Exit(-1);
            }
            if (!kekcrack)
            {
                Environment.Exit(-1);
            }
            if (!kekcrack)
            {
                Environment.Exit(-1);
            }
            if (!kekcrack)
            {
                Environment.Exit(-1);
            }
            if (!kekcrack)
            {
                Environment.Exit(-1);
            }
            if (!kekcrack)
            {
                Environment.Exit(-1);
            }
            if (!kekcrack)
            {
                Environment.Exit(-1);
            }
            Console.WriteLine("Success!");
            Task.Delay(1000).Wait();
        Start1:
            Console.WriteLine("Enter help for commdands");
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("phantom$ ");
                Console.ResetColor();
                string cmdinput1 = Console.ReadLine();
                switch (cmdinput1)
                {
                    case var s when s.StartsWith("help"):
                        Console.WriteLine("Phantom CMDS\nperm - Perm spoof\ncheck - check serials | aliases: serials, serial\nclean - AppleCleaner");
                        break;
                    case var s when s.StartsWith("perm"):
                        try
                        {
                            Other.Natives.BlockInput(true);
                            if (!Directory.Exists("C:\\PhantomSolutions"))
                            {
                                Directory.CreateDirectory("C:\\PhantomSolutions");
                            }
                            File.WriteAllBytes("C:\\PhantomSolutions\\zhjers.exe", Files.PLoader.rawData);
                            File.WriteAllBytes("C:\\PhantomSolutions\\AMIFLDRV64.SYS", Files.PDrv1.rawData);
                            File.WriteAllBytes("C:\\PhantomSolutions\\dvlwwwdrv64.sys", Files.PDrv2.rawData);
                            Tasks.Run.runpdrv();
                            Tasks.Run.resetwinmgmt();
                            File.Delete("C:\\PhantomSolutions\\zhjers.exe");
                            File.Delete("C:\\PhantomSolutions\\AMIFLDRV64.SYS");
                            File.Delete("C:\\PhantomSolutions\\dvlwwwdrv64.sys");
                            if (File.Exists("C:\\PhantomSolutions\\AppleCleaner.exe"))
                            {
                                File.Delete("C:\\PhantomSolutions\\AppleCleaner.exe");
                            }
                            Other.Natives.BlockInput(false);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("[+]");
                            Console.ResetColor();
                            Console.WriteLine(" Success");
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("[-]");
                            Console.ResetColor();
                            Console.WriteLine(" Something went wrong...");
                        }
                        break;
                    case var s when s.StartsWith("clean"):
                        try
                        {
                            if (!Directory.Exists("C:\\PhantomSolutions"))
                            {
                                Directory.CreateDirectory("C:\\PhantomSolutions");
                            }
                            File.WriteAllBytes("C:\\PhantomSolutions\\AppleCleaner.exe", Files.AppleCleaner.rawData);
                            Tasks.Run.CMD("start C:\\PhantomSolutions\\AppleCleaner.exe");
                            File.Delete("C:\\PhantomSolutions\\AppleCleaner.exe");
                        } catch
                        {

                        }
                        break;
                    case var s when s.StartsWith("serial"):
                        if (!Tasks.check.serials())
                        {
                            Console.WriteLine("Something went wrong...");
                        }
                        break;
                    case var s when s.StartsWith("check"):
                        if (!Tasks.check.serials())
                        {
                            Console.WriteLine("Something went wrong...");
                        }
                        break;
                    default:
                        Console.WriteLine(cmdinput1 + " is not a valid command");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
