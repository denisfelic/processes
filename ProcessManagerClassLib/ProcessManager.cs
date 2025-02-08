using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessManagerClassLib
{
    public class ProcessManager
    {
        public void ListProcesses()
        {
            var processes = Process.GetProcesses();

            processes.ToList().ForEach(p =>
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("Name, PID, Status");
                Console.WriteLine($"{p.ProcessName}, {p.Id}, {IsRunning(p.ProcessName)}");
                Console.WriteLine("-----------------------------------------------------");
            });
        }

        public static bool IsRunning(string name) => Process.GetProcessesByName(name).Length > 0;

    }
}