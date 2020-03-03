using System;
using System.Linq;

namespace Top_5_applicaties_RAM_verbruik
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pas aan: enkel top 5
            var query = (from p in System.Diagnostics.Process.GetProcesses()
                         orderby p.PrivateMemorySize64 descending
                         select p)
                             //.Skip(0)
                             .Take(5)
                             .ToList();
            foreach (var item in query)
            {
                System.Console.WriteLine(item.ProcessName);
            }
            Console.ReadKey();
        }
    }
}
