using GenericParsing;
using Straten;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace StratenImport.Providers
{
    public class RegiosProvider
    {
        #region Fields
        private GemeentenProvider _gemeentenProvider;
        private Land _land;
        #endregion

        #region Ctor
        public RegiosProvider(Land land)
        {
            _land = land;
        }
        #endregion

        #region Methods
        public void Get()
        {
#if DEBUG
            DebugWriter.WriteLine("-> RegiosProvider::Read");
            var timer = new Stopwatch();
            timer.Start();
#endif
            string provincieIds = null;
            StreamReader file = new System.IO.StreamReader(Config.Path + "/" + Config.ProvincieIds);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                provincieIds = line;
            }
            file.Close();
            if (provincieIds == null) return;
            string[] provincieIdArray = provincieIds.Trim().Split(',');

            var provincies = new List<string>(provincieIdArray);
            if (provincies == null || provincies.Count == 0) return;

            _gemeentenProvider = new GemeentenProvider(_land.TaalCode);
            Dictionary<int, Gemeente> gemeenten = _gemeentenProvider.GetGemeenten();
            if (gemeenten == null || gemeenten.Count == 0) return;

            GetProvinciesGemeenten(provincies, gemeenten);

#if DEBUG
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            DebugWriter.WriteLine("<- RegiosProvider::Read: " + timeTaken.ToString(@"m\:ss\.fff"));
#endif
        }

        private void GetProvinciesGemeenten(List<string> provincies, Dictionary<int, Gemeente> gemeenten)
        {
#if DEBUG
            DebugWriter.WriteLine("-> RegiosProvider::ReadProvinciesGemeenten");
            var timer = new Stopwatch();
            timer.Start();
#endif
            using GenericParser provincieGemeentenReader = new GenericParser(Config.Path + "/" + Config.ProvincieInfo)
            {
                ColumnDelimiter = ';',
                FirstRowHasHeader = true,
                MaxBufferSize = 4096
            };

            while (provincieGemeentenReader.Read())
            {
                var id = provincieGemeentenReader[1].Trim();
                var naam = provincieGemeentenReader[3].Trim();
                var taalCode = provincieGemeentenReader[2].Trim();
                if (taalCode != _land.TaalCode) continue;
                if (provincies.Contains(provincieGemeentenReader[1].Trim()))
                {
                    Provincie p;
                    foreach (var regio in _land.Regios.Values)
                    {
                        if (regio.Provincies.ContainsKey(provincieGemeentenReader[3].Trim()))
                        {
                            p = regio.Provincies[provincieGemeentenReader[3].Trim()];
                        }
                        else
                        {

                            p = new Provincie { Id = int.Parse(id), Naam = naam, TaalCode = taalCode, Regio = regio };
                            regio.Provincies.Add(p.Naam, p);
                        }
                        var key = int.Parse(provincieGemeentenReader[0].Trim());
                        if (gemeenten.ContainsKey(key))
                        {
                            var gemeente = gemeenten[key];
                            if (gemeente.Provincie == null)
                                gemeente.Provincie = p;
                            else
                                throw new Exception("Gemeente behoort reeds tot andere provincie");
                            if (!p.Gemeenten.ContainsKey(gemeente.Naam))
                            {
                                p.Gemeenten.Add(gemeente.Naam, gemeente);
                            }
                        }
                    }
                }
            }
#if DEBUG
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            DebugWriter.WriteLine("<- RegiosProvider::ReadProvinciesGemeenten: " + timeTaken.ToString(@"m\:ss\.fff"));
#endif
        }
        #endregion
    }
}
