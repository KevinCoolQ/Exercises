using System;
using System.Linq;

namespace Top_5_applicaties_RAM_verbruik
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pas aan: enkel top 5
            var query = System.Diagnostics.Process.GetProcesses();
            foreach (var item in query)
            {
                System.Diagnostics.Debug.WriteLine(item.ProcessName);
            }
        }
    }
}
