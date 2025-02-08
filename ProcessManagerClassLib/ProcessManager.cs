using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessManagerClassLib
{
    public record ProcessDto(int Id, string Name, bool Status);

    public class ProcessManager
    {
        public List<ProcessDto> GetActiveProcesses()
        {
            var processes = Process.GetProcesses();
            var processesList = new List<ProcessDto>();

            processes.ToList().ForEach(p =>
            {
                var newP = new ProcessDto(
                       Id: p.Id,
                       Name: p.ProcessName,
                       Status: IsRunning(p.ProcessName)
                );
                processesList.Add(newP);

            });
            return processesList;

        }

        public static bool IsRunning(string name) => Process.GetProcessesByName(name).Length > 0;

    }
}