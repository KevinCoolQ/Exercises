using Straten;
using Straten.Interfaces;
using Straten.Exporters;
using StratenExport.Providers;
using System;
using System.Collections.Generic;

namespace StratenExport
{
    static public class Program
    {
        static int Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: StratenExport.exe <city>");
                return 1; // OS: 0 == ok, != 0 == failure
            }
            string gemeente = args[0];

            // Ctor verdient voorkeur: schrijf om
            Land land = new Land { Id = 1, Naam = "Belgie", TaalCode = "nl" };
            List<IExporter> exporters = new List<IExporter> { new FileExporter(land), new ConsoleExporter(land) };

            var regio = new Regio { Id = 1, Naam = "Vlaanderen", Land = land };
            land.Regios.Add(regio.Naam, regio); // SortedList

            LandProvider landProvider = new LandProvider(land);
            landProvider.Load(); // Lees binary dump file

            foreach (var exporter in exporters)
            {
                exporter.Export(gemeente);
            }

            return 0;
        }
    }
}
