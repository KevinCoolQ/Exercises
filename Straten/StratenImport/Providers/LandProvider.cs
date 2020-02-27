using Straten;
using Straten.Providers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace StratenImport.Providers
{
    public class LandProvider
    {
        #region Fields
        private RegiosProvider _regiosProvider;
        private StratenProvider _stratenProvider;
        private Land _land;
        #endregion

        #region Ctor
        public LandProvider(Land land)
        {
            _land = land;
        }
        #endregion

        #region Methods
        public void Read()
        {
            // Precompiler: in Debug mode is code aanwezig, anders niet
#if DEBUG
            DebugWriter.WriteLine("-> LandProvider::Read");
            var timer = new Stopwatch();
            timer.Start();
#endif
            _regiosProvider = new RegiosProvider(_land);
            _regiosProvider.Get();
            /*
            foreach (var regio in _land.Regios.Values)
            {
                regio.Read(_land);
            }
            */
            _stratenProvider = new StratenProvider();
            HaalStratenOp(_stratenProvider);

#if DEBUG
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            DebugWriter.WriteLine("<- LandProvider::Read: " + timeTaken.ToString(@"m\:ss\.fff"));
#endif
        }

        private void HaalStratenOp(StratenProvider stratenProvider)
        {
#if DEBUG
            DebugWriter.WriteLine("-> LandProvider::HaalStratenOp");
            var timer = new Stopwatch();
            timer.Start();
#endif
            foreach (var r in _land.Regios.Values)
            {
                foreach (var p in r.Provincies.Values)
                {
                    foreach (var g in p.Gemeenten.Values)
                    {
                        var straten = stratenProvider.GetStraten(g.Id);
                        foreach (var straat in straten)
                        {
                            g.Straten.Add(straat, new Straat
                            {
                                Id = g.Id,
                                Naam = straat,
                                Gemeente = g
                            });
                        }
                    }
                }
            }
#if DEBUG
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            DebugWriter.WriteLine("<- LandProvider::HaalStratenOp: " + timeTaken.ToString(@"m\:ss\.fff"));
#endif
        }
        #endregion
    }
}
