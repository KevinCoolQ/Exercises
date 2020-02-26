using System;
using System.Diagnostics;
using System.IO;

namespace Straten.Exporters
{
    public class ConsoleExporter: Interfaces.IExporter
    {
        #region Fields
        private Land _land;
        #endregion

        #region Ctor
        public ConsoleExporter(Land land)
        {
            this._land = land;
        }
        #endregion

        #region Methods
        public void Export(string gemeente)
        {
#if DEBUG
            DebugWriter.WriteLine("-> FileExporter::Export");
            var timer = new Stopwatch();
            timer.Start();
#endif
            foreach (var r in _land.Regios.Values)
            {
                foreach (var p in r.Provincies.Values)
                {
                    foreach (var g in p.Gemeenten.Values)
                    {
                        if (g.Naam == gemeente)
                        {
                            var currentDirName = Directory.GetCurrentDirectory();
                            var dirName = "./" + _land.Naam + "/" + r.Naam + "/" + p.Naam + "/" + g.Naam;
                            foreach (var s in g.Straten)
                            {
                                Console.WriteLine(dirName + "/" + s.Value.Naam);
                            }
                        }
                    }
                }
            }
#if DEBUG
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            DebugWriter.WriteLine("<- FileExporter::Export: " + timeTaken.ToString(@"m\:ss\.fff"));
#endif
        }
        #endregion
    }
}