using GenericParsing;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Straten.Providers
{
    public class StratenProvider
    {
        #region Properties
        private Dictionary<int, List<int>> _gemeenteStraat { get; set; } = new Dictionary<int, List<int>>();
        private Dictionary<int, string> _straten { get; set; } = new Dictionary<int, string>();
        #endregion

        #region Ctor
        public StratenProvider()
        {
            Read();
        }
        #endregion

        #region Methods
        private void Read()
        {
#if DEBUG
            DebugWriter.WriteLine("-> StratenProvider::Read");
            var timer = new Stopwatch();
            timer.Start();
#endif
            using GenericParser stratenGemeenteReader = new GenericParser(Config.Path + "/" + Config.StraatnaamGemeenteId)
            {
                ColumnDelimiter = ';',
                FirstRowHasHeader = true,
                MaxBufferSize = 4096
            };
            while (stratenGemeenteReader.Read())
            {
                if (_gemeenteStraat.ContainsKey(int.Parse(stratenGemeenteReader[1].Trim())))
                {
                    _gemeenteStraat[int.Parse(stratenGemeenteReader[1].Trim())].Add(int.Parse(stratenGemeenteReader[0].Trim()));
                }
                else
                {
                    _gemeenteStraat.Add(int.Parse(stratenGemeenteReader[1].Trim()), new List<int> { int.Parse(stratenGemeenteReader[0].Trim()) });
                }
            }
            DebugWriter.WriteLine("Straten/gemeenten links: " + _gemeenteStraat.Count);

            using GenericParser stratenReader = new GenericParser(Config.Path + "/" + Config.Straatnamen)
            {
                ColumnDelimiter = ';',
                FirstRowHasHeader = true,
                MaxBufferSize = 4096
            };
            while (stratenReader.Read())
            {
                var id = stratenReader[0] != null ? int.Parse(stratenReader[0].Trim()) : -1;
                var naam = stratenReader[1] != null ? stratenReader[1].Trim() : "";
                if (id != -1 && !string.IsNullOrEmpty(naam))
                    _straten.Add(id, naam);
            }
            DebugWriter.WriteLine("Straten: " + _straten.Count);

//#if DEBUG
//            timer.Stop();
//            TimeSpan timeTaken = timer.Elapsed;
//            DebugWriter.WriteLine("<- StratenProvider::Read: " + timeTaken.ToString(@"m\:ss\.fff"));
//#endif
        }

        /// <summary>
        /// Set: elk element is uniek (komt maar 1 keer voor)
        /// </summary>
        /// <param name="gemeenteId"></param>
        /// <returns></returns>
        public SortedSet<string> GetStraten(int gemeenteId)
        {
            SortedSet<string> straten = new SortedSet<string>();
            if (_gemeenteStraat.ContainsKey(gemeenteId))
            {
                foreach (var straatId in _gemeenteStraat[gemeenteId])
                {
                    if (_straten.ContainsKey(straatId) && !straten.Contains(_straten[straatId]))
                        straten.Add(_straten[straatId]);
                }
            }
            return straten;
        }
        #endregion
    }
}
