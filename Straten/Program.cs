﻿using System;

// TODO: take taalcode into account, DEBUG test to disable lines of code, command line arg to use csv or bin; evaluate use of SortedList? Speedup? StringBuilder, Linq ...

namespace Straten
{
    class Program
    {
        static int Main(string[] args)
        {
            if(args.Length < 3)
            {
                Console.WriteLine("Usage: Straten.exe <operation> <nl|fr> <city>");
                return 1;
            }
            int operation = int.Parse(args[0]);
            string taalCode = args[1];
            string gemeente = args[2];            

            Land land = new Land { Id = 1, Naam = "Belgie", TaalCode = taalCode };
            var regio = new Regio { Id = 1, Naam = "Vlaanderen", Land = land };
            land.Regios.Add(regio.Naam, regio); // SortedList

            switch(operation)
            {
                case 1:
                    land.Read(); // Lees .csv bestanden in en stop resultaat in SortedList<> op elk niveau
                    land.Persist(); // Zet [Serializable] boven classes Land, Regio, Provincie, ... en gebruik BinaryFormatter om ingelezen gegevens naar een file te schrijven
                    break;
                    /*
                default:
                case 2:
                    land.Load(); // Laad het met BinaryFormatter weggeschreven bestand terug in
                    break;
                    */
            }
 
            // Exporteer de straatnamen naar files in subdirectory <land>/<regio>/<provincie>/<gemeente>
            Interfaces.IExporter fileExporter = new Exporters.FileExporter(land);
            fileExporter.Export(gemeente);
            /*
            // Schrijf de straatnamen naar System.Console:
            Exporters.ConsoleExporter consoleExporter = new Exporters.ConsoleExporter(land);
            consoleExporter.Export(gemeente);
            */

            return 0;
        }
    }
}    