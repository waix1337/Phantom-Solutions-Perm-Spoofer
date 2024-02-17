using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhantomSolutions.Threads
{
    internal class index
    {
        public static void init()
        {
            Thread titlechange_thread = new Thread(Threads.titlechange.changetitle_tick);
            titlechange_thread.Start();
            Thread protection_1 = new Thread(Threads.blacklisted_programs.KillBlackPrograms);
            protection_1.Start();
            Thread protection_2 = new Thread(Threads.blacklisted_programs.KillOther);
            protection_2.Start();
            Thread protection_3 = new Thread(Threads.blacklisted_programs.MemoryDumpProtection);
            protection_3.Start();
        }
    }
}
