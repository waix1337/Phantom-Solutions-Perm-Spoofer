using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhantomSolutions.Tasks
{
    internal class check
    {
        public static bool serials()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Disk Drive");
                Console.ResetColor();
                Other.Natives.GetWMICProperty("Win32_DiskDrive", "Model");
                Other.Natives.GetWMICProperty("Win32_DiskDrive", "SerialNumber");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("CPU");
                Console.ResetColor();
                Other.Natives.GetWMICProperty("Win32_Processor", "SerialNumber");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("BIOS");
                Console.ResetColor();
                Other.Natives.GetWMICProperty("Win32_BIOS", "SerialNumber");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Motherboard");
                Console.ResetColor();
                Other.Natives.GetWMICProperty("Win32_BaseBoard", "SerialNumber");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("smBIOS UUID");
                Console.ResetColor();
                Other.Natives.GetWMICProperty("Win32_ComputerSystemProduct", "UUID");
                return true;
            } catch
            {
                return false;
            }
        }
    }
}
