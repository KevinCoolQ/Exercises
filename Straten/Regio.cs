using GenericParsing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Straten
{
    [Serializable]
    public class Regio
    {
        #region Properties
        public int Id { get; set; }
        public string Naam { get; set; }

        /// <summary>
        /// Parent: geen copie!
        /// </summary>
        public Land Land { get; set; }

        /// <summary>
        /// Children
        /// </summary>

        public SortedList<string, Provincie> Provincies { get; set; } = new SortedList<string, Provincie>();
        #endregion

        #region Methods
        private Dictionary<int, Gemeente> ReadGemeenten()
        {
#if DEBUG
            DebugWriter.WriteLine("-> Regio::ReadGemeenten");
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
                //if (gemeentenReader[2].Trim() != Land.TaalCode) continue;
                gemeenten.Add(int.Parse(gemeentenReader[0].Trim()), new Gemeente { NaamId = int.Parse(gemeentenReader[0].Trim()), Id = int.Parse(gemeentenReader[1].Trim()), TaalCode = gemeentenReader[2].Trim(), Naam = gemeentenReader[3].Trim() });                
            }
            DebugWriter.WriteLine("Gemeenten: " + gemeenten.Values.Count);

#if DEBUG
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            DebugWriter.WriteLine("<- Regio::ReadGemeenten: " + timeTaken.ToString(@"m\:ss\.fff"));
#endif            
            return gemeenten;
        }

        private void ReadProvinciesGemeenten(Land land, List<string> provincies, Dictionary<int, Gemeente> gemeenten)
        {
#if DEBUG
            DebugWriter.WriteLine("-> Regio::ReadProvinciesGemeenten");
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
                if (taalCode != Land.TaalCode) continue;                
                if (provincies.Contains(provincieGemeentenReader[1].Trim()))
                {
                    // gemeenteId;provincieId;taalCode;provincieNaam
                    Provincie p;
                    foreach (var regio in land.Regios.Values)
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
                        var gemeente = gemeenten[int.Parse(provincieGemeentenReader[0].Trim())];
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
#if DEBUG
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            DebugWriter.WriteLine("<- Regio::ReadProvinciesGemeenten: " + timeTaken.ToString(@"m\:ss\.fff"));
#endif
        }

        public void Read()
        {
#if DEBUG
            DebugWriter.WriteLine("-> Regio::Read");
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

            Dictionary<int, Gemeente> gemeenten = ReadGemeenten();
            if (gemeenten == null || gemeenten.Count == 0) return;

            ReadProvinciesGemeenten(Land, provincies, gemeenten);

#if DEBUG
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            DebugWriter.WriteLine("<- Regio::Read: " + timeTaken.ToString(@"m\:ss\.fff"));
#endif
        }
        #endregion
    }
}
