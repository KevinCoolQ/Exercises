using GenericParsing;
using Straten;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StratenImport.Providers
{
    public class GemeentenProvider
    {
        #region Fields
        private string _taalCode;
        #endregion

        #region Ctor
        public GemeentenProvider(string taalCode)
        {
            _taalCode = taalCode;
        }
        #endregion

        #region Methods
        public Dictionary<int, Gemeente> GetGemeenten()
        {
#if DEBUG
            DebugWriter.WriteLine("-> GemeentenProvider::GetGemeenten");
            var timer = new Stopwatch();
            timer.Start();
#endif
            Dictionary<int, Gemeente> gemeenten = new Dictionary<int, Gemeente>();

            using GenericParser gemeentenReader = new GenericParser(Config.Path + "/" + Config.Gemeentenamen)
            {
                ColumnDelimiter = ';',
                FirstRowHasHeader = true,
                MaxBufferSize = 4096
            };
            while (gemeentenReader.Read())
            {
                if (gemeentenReader[2].Trim() != _taalCode) continue;
                gemeenten.Add(int.Parse(gemeentenReader[1].Trim()), new Gemeente { NaamId = int.Parse(gemeentenReader[0].Trim()), Id = int.Parse(gemeentenReader[1].Trim()), TaalCode = gemeentenReader[2].Trim(), Naam = gemeentenReader[3].Trim() });
            }
            DebugWriter.WriteLine("Gemeenten: " + gemeenten.Values.Count);

#if DEBUG
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            DebugWriter.WriteLine("<- GemeentenProvider::GetGemeenten: " + timeTaken.ToString(@"m\:ss\.fff"));
#endif            
            return gemeenten;
        }
        #endregion
    }
}
