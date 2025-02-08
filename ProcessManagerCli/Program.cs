// See https://aka.ms/new-console-template for more information
using ProcessManagerClassLib;

Console.WriteLine("Hello, World!");


var processManager = new ProcessManager();
var processList = processManager.GetActiveProcesses();

foreach (var p in processList)
{
    Console.WriteLine("-----------------------------------------------------");
    Console.WriteLine("Name, PID, Status");
    Console.WriteLine($"{p.Name}, {p.Id}, {p.Status}");
    Console.WriteLine("-----------------------------------------------------");
}