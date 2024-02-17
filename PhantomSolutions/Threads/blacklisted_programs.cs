using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhantomSolutions.Threads
{
    internal unsafe class blacklisted_programs
    {
        private struct STARTUPINFO
        {
            public uint cb;
            public string lpReserved;
            public string lpDesktop;
            public string lpTitle;
            public uint dwX;
            public uint dwY;
            public uint dwXSize;
            public uint dwYSize;
            public uint dwXCountChars;
            public uint dwYCountChars;
            public uint dwFillAttribute;
            public uint dwFlags;
            public short wShowWindow;
            public short cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }
        [DllImport("kernel32.dll", EntryPoint = "GetModuleHandle")]
        private static extern IntPtr GenericAcl(string lpModuleName);
        [DllImport("kernel32.dll", EntryPoint = "GetProcAddress")]
        private static extern IntPtr TryCode(IntPtr hModule, string procName);
        [DllImport("kernel32.dll", EntryPoint = "GetFileAttributes", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern uint ISymbolReader(string lpFileName);
        [DllImport("kernel32.dll")]
        private static extern IntPtr ZeroMemory(IntPtr addr, IntPtr size);
        [DllImport("kernel32.dll")]
        private static extern IntPtr VirtualProtect(IntPtr lpAddress, IntPtr dwSize, IntPtr flNewProtect, ref IntPtr lpflOldProtect);
        [DllImport("kernel32", EntryPoint = "SetProcessWorkingSetSize")]
        private static extern int OneWayAttribute([In] IntPtr obj0, [In] int obj1, [In] int obj2);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CreateProcess(string lpApplicationName, string lpCommandLine, IntPtr lpProcessAttributes, IntPtr lpThreadAttributes, bool bInheritHandles, uint dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, ref STARTUPINFO lpstartupfaggot, int[] lpProcessInfo);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern uint NtUnmapViewOfSection(IntPtr hProcess, IntPtr lpBaseAddress);
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtWriteVirtualMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, uint nSize, IntPtr lpNumberOfBytesWritten);
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtGetContextThread(IntPtr hThread, IntPtr lpContext);
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSetContextThread(IntPtr hThread, IntPtr lpContext);
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern uint NtResumeThread(IntPtr hThread, IntPtr SuspendCount);
        private static string SoapNcName([In] string obj0, [In] string obj1)
        {
            var registryKey = Registry.LocalMachine.OpenSubKey(obj0, false);
            if (registryKey == null)
                return "noKey";
            var obj = registryKey.GetValue(obj1, "noValueButYesKey");
            if (obj is string || registryKey.GetValueKind(obj1) == RegistryValueKind.String || registryKey.GetValueKind(obj1) == RegistryValueKind.ExpandString)
                return obj.ToString();
            if (registryKey.GetValueKind(obj1) == RegistryValueKind.DWord)
                return Convert.ToString((int)obj);
            if (registryKey.GetValueKind(obj1) == RegistryValueKind.QWord)
                return Convert.ToString((long)obj);
            if (registryKey.GetValueKind(obj1) == RegistryValueKind.Binary)
                return Convert.ToString((byte[])obj);
            if (registryKey.GetValueKind(obj1) == RegistryValueKind.MultiString)
                return string.Join("", (string[])obj);
            return "noValueButYesKey";
        }
        private static bool MessageDictionary()
        {
            if (SoapNcName("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 0\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("VBOX") ||
                SoapNcName("HARDWARE\\Description\\System", "SystemBiosVersion").ToUpper().Contains("VBOX") ||
                SoapNcName("HARDWARE\\Description\\System", "VideoBiosVersion").ToUpper().Contains("VIRTUALBOX") ||
                SoapNcName("SOFTWARE\\Oracle\\VirtualBox Guest Additions", "") == "noValueButYesKey" || (int)ISymbolReader("C:\\WINDOWS\\system32\\drivers\\VBoxMouse.sys") != -1 ||
                SoapNcName("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 0\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("VMWARE") ||
                SoapNcName("SOFTWARE\\VMware, Inc.\\VMware Tools", "") == "noValueButYesKey" ||
                SoapNcName("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 1\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("VMWARE")
                || SoapNcName("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 2\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("VMWARE") ||
                SoapNcName("SYSTEM\\ControlSet001\\Services\\Disk\\Enum", "0").ToUpper().Contains("vmware".ToUpper()) ||
                SoapNcName("SYSTEM\\ControlSet001\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", "DriverDesc").ToUpper().Contains("VMWARE") ||
                SoapNcName("SYSTEM\\ControlSet001\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000\\Settings", "Device Description").ToUpper().Contains("VMWARE") ||
                SoapNcName("SOFTWARE\\VMware, Inc.\\VMware Tools", "InstallPath").ToUpper().Contains("C:\\PROGRAM FILES\\VMWARE\\VMWARE TOOLS\\") ||
                (int)ISymbolReader("C:\\WINDOWS\\system32\\drivers\\vmmouse.sys") != -1 || (int)ISymbolReader("C:\\WINDOWS\\system32\\drivers\\vmhgfs.sys") != -1 ||
                TryCode(GenericAcl("kernel32.dll"), "wine_get_unix_file_name") != (IntPtr)0 ||
                SoapNcName("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 0\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("QEMU") ||
                SoapNcName("HARDWARE\\Description\\System", "SystemBiosVersion").ToUpper().Contains("QEMU"))
                return true;
            return false;
        }
        private static int[] sectiontabledwords = new int[] { 0x8, 0xC, 0x10, 0x14, 0x18, 0x1C, 0x24 };
        private static int[] peheaderbytes = new int[] { 0x1A, 0x1B };
        private static int[] peheaderwords = new int[] { 0x4, 0x16, 0x18, 0x40, 0x42, 0x44, 0x46, 0x48, 0x4A, 0x4C, 0x5C, 0x5E };
        private static int[] peheaderdwords = new int[] { 0x0, 0x8, 0xC, 0x10, 0x16, 0x1C, 0x20, 0x28, 0x2C, 0x34, 0x3C, 0x4C, 0x50, 0x54, 0x58, 0x60, 0x64, 0x68, 0x6C, 0x70, 0x74, 0x104, 0x108, 0x10C, 0x110, 0x114, 0x11C };
        private static void EraseSection(IntPtr address, int size)
        {
            IntPtr sz = (IntPtr)size;
            IntPtr dwOld = default(IntPtr);
            VirtualProtect(address, sz, (IntPtr)0x40, ref dwOld);
            ZeroMemory(address, sz);
            IntPtr temp = default(IntPtr);
            VirtualProtect(address, sz, dwOld, ref temp);
        }
        private static IntPtr GetModuleHandle(string libName)
        {
            foreach (ProcessModule pMod in Process.GetCurrentProcess().Modules)
                if (pMod.ModuleName.ToLower().Contains(libName.ToLower()))
                    return pMod.BaseAddress;
            return IntPtr.Zero;
        }
        public static void AntiDump()
        {
            var process = System.Diagnostics.Process.GetCurrentProcess();
            var base_address = process.MainModule.BaseAddress;
            var dwpeheader = System.Runtime.InteropServices.Marshal.ReadInt32((IntPtr)(base_address.ToInt32() + 0x3C));
            var wnumberofsections = System.Runtime.InteropServices.Marshal.ReadInt16((IntPtr)(base_address.ToInt32() + dwpeheader + 0x6));

            for (int i = 0; i < peheaderwords.Length; i++)
            {
                EraseSection((IntPtr)(base_address.ToInt32() + dwpeheader + peheaderwords[i]), 2);
            }
            for (int i = 0; i < peheaderbytes.Length; i++)
            {
                EraseSection((IntPtr)(base_address.ToInt32() + dwpeheader + peheaderbytes[i]), 1);
            }

            int x = 0;
            int y = 0;

            while (x <= wnumberofsections)
            {
                if (y == 0)
                {
                    EraseSection((IntPtr)((base_address.ToInt32() + dwpeheader + 0xFA + (0x28 * x)) + 0x20), 2);
                }


                y++;

                if (y == sectiontabledwords.Length)
                {
                    x++;
                    y = 0;
                }
            }
        }
        public static void KillOther()
        {
            while (true)
            {
                AntiDump();
                if (IsSandboxie())
                {
                    Environment.Exit(-69420000);
                }
            }
        }
        public static void KillBlackPrograms()
        {
            while (true)
            {
                Tasks.Run.CMD("taskkill /f /im HTTPDebuggerUI.exe >nul 2>&1");
                Tasks.Run.CMD("taskkill /f /im HTTPDebuggerSvc.exe >nul 2>&1");
                Tasks.Run.CMD("taskkill /f /im Ida64.exe >nul 2>&1");
                Tasks.Run.CMD("taskkill /f /im OllyDbg.exe >nul 2>&1");
                Tasks.Run.CMD("taskkill /f /im Dbg64.exe >nul 2>&1");
                Tasks.Run.CMD("taskkill /f /im Dbg32.exe >nul 2>&1");
                Tasks.Run.CMD("sc stop HTTPDebuggerPro >nul 2>&1");
                Tasks.Run.CMD("taskkill /FI \"IMAGENAME eq cheatengine*\" /IM * /F /T >nul 2>&1");
                Tasks.Run.CMD("taskkill /FI \"IMAGENAME eq httpdebugger*\" /IM * /F /T >nul 2>&1");
                Tasks.Run.CMD("taskkill /FI \"IMAGENAME eq processhacker*\" /IM * /F /T >nul 2>&1");
                Tasks.Run.CMD("taskkill /f /im HTTPDebuggerUI.exe >nul 2>&1");
                Tasks.Run.CMD("taskkill /f /im HTTPDebuggerSvc.exe >nul 2>&1");
                Tasks.Run.CMD("sc stop HTTPDebuggerPro >nul 2>&1");
                Tasks.Run.CMD("taskkill /FI \"IMAGENAME eq cheatengine*\" /IM * /F /T >nul 2>&1");
                Tasks.Run.CMD("taskkill /FI \"IMAGENAME eq httpdebugger*\" /IM * /F /T >nul 2>&1");
                Tasks.Run.CMD("taskkill /FI \"IMAGENAME eq processhacker*\" /IM * /F /T >nul 2>&1");
                Tasks.Run.CMD("taskkill /FI \"IMAGENAME eq x64dbg*\" /IM * /F /T >nul 2>&1");
                Tasks.Run.CMD("taskkill /FI \"IMAGENAME eq x32dbg*\" /IM * /F /T >nul 2>&1");
                Tasks.Run.CMD("taskkill /FI \"IMAGENAME eq ollydbg*\" /IM * /F /T >nul 2>&1");
                Tasks.Run.CMD("taskkill /FI \"IMAGENAME eq fiddler*\" /IM * /F /T >nul 2>&1");
                Tasks.Run.CMD("taskkill /FI \"IMAGENAME eq fiddler*\" /IM * /F /T >nul 2>&1");
                Tasks.Run.CMD("taskkill /FI \"IMAGENAME eq charles*\" /IM * /F /T >nul 2>&1");
                Tasks.Run.CMD("taskkill /FI \"IMAGENAME eq cheatengine*\" /IM * /F /T >nul 2>&1");
                Tasks.Run.CMD("taskkill /FI \"IMAGENAME eq ida*\" /IM * /F /T >nul 2>&1");
                Tasks.Run.CMD("taskkill /FI \"IMAGENAME eq httpdebugger*\" /IM * /F /T >nul 2>&1");
                Tasks.Run.CMD("taskkill /FI \"IMAGENAME eq processhacker*\" /IM * /F /T >nul 2>&1");
                Tasks.Run.CMD("sc stop HTTPDebuggerPro >nul 2>&1");
                Tasks.Run.CMD("sc stop HTTPDebuggerProSdk >nul 2>&1");
                Tasks.Run.CMD("sc stop KProcessHacker3 >nul 2>&1");
                Tasks.Run.CMD("sc stop KProcessHacker2 >nul 2>&1");
                Tasks.Run.CMD("sc stop KProcessHacker1 >nul 2>&1");
                Tasks.Run.CMD("sc stop wireshark >nul 2>&1");
                Tasks.Run.CMD("taskkill /f /im HTTPDebuggerUI.exe >nul 2>&1");
                Tasks.Run.CMD("taskkill /f /im HTTPDebuggerSvc.exe >nul 2>&1");
                Tasks.Run.CMD("sc stop HTTPDebuggerPro >nul 2>&1");
                Tasks.Run.CMD("taskkill /FI \"IMAGENAME eq cheatengine*\" /IM * /F /T >nul 2>&1");
                Tasks.Run.CMD("taskkill /FI \"IMAGENAME eq httpdebugger*\" /IM * /F /T >nul 2>&1");
                Tasks.Run.CMD("taskkill /FI \"IMAGENAME eq processhacker*\" /IM * /F /T >nul 2>&1");
                Tasks.Run.CMD("taskkill /FI \"IMAGENAME eq x64dbg*\" /IM * /F /T >nul 2>&1");
                Tasks.Run.CMD("taskkill /FI \"IMAGENAME eq x32dbg*\" /IM * /F /T >nul 2>&1");
                Tasks.Run.CMD("taskkill /FI \"IMAGENAME eq ollydbg*\" /IM * /F /T >nul 2>&1");
                Tasks.Run.CMD("taskkill /FI \"IMAGENAME eq fiddler*\" /IM * /F /T >nul 2>&1");
                Tasks.Run.CMD("taskkill /FI \"IMAGENAME eq die*\" /IM * /F /T >nul 2>&1");
                Tasks.Run.CMD("taskkill /f /im HTTPDebuggerSvc.exe >nul 2>&1");
                Tasks.Run.CMD("taskkill /f /im HTTPDebugger.exe >nul 2>&1");
                Tasks.Run.CMD("taskkill /f /im FolderChangesView.exe >nul 2>&1");
                Tasks.Run.CMD("sc stop HttpDebuggerSdk >nul 2>&1");
                Tasks.Run.CMD("sc stop npf >nul 2>&1");
            }
        }
        private static bool IsSandboxie()
        {
            if (GetModuleHandle("SbieDll.dll") != IntPtr.Zero)
                return true;
            return false;
        }
        public static void MemoryDumpProtection()
        {
            var handle = Process.GetCurrentProcess().Handle;
            while (true)
            {
                do
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                } while (Environment.OSVersion.Platform != PlatformID.Win32NT);

                OneWayAttribute(handle, -1, -1);
            }
        }
    }
}
