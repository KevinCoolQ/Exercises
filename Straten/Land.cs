using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Straten
{
    [Serializable]
    public class Land
    {
        #region Fields
        [NonSerialized()]
        private Providers.StratenProvider _stratenProvider;
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Naam { get; set; }
        public string TaalCode { get; set; }

        /// <summary>
        /// Children
        /// </summary>
        public SortedList<string, Regio> Regios { get; set; } = new SortedList<string, Regio>();
        #endregion

        #region Ctor
        public Land()
        {
        }
        #endregion

        #region Methods
        public void Read()
        {
#if DEBUG
            DebugWriter.WriteLine("-> Land::Read");
            var timer = new Stopwatch();
            timer.Start();
#endif
            foreach (var regio in Regios.Values)
            {
                regio.Read();
            }

            _stratenProvider = new Providers.StratenProvider();
            HaalStratenOp(_stratenProvider);

#if DEBUG
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            DebugWriter.WriteLine("<- Land::Read: " + timeTaken.ToString(@"m\:ss\.fff"));
#endif
        }

        private void HaalStratenOp(Providers.StratenProvider stratenProvider)
        {
#if DEBUG
            DebugWriter.WriteLine("-> Land::HaalStratenOp");
            var timer = new Stopwatch();
            timer.Start();
#endif
            foreach (var r in Regios.Values)
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
            DebugWriter.WriteLine("<- Land::HaalStratenOp: " + timeTaken.ToString(@"m\:ss\.fff"));
#endif
        }

        public void Persist()
        {
#if DEBUG
            DebugWriter.WriteLine("-> Land::Persist");
            var timer = new Stopwatch();
            timer.Start();
#endif

            Stream stream = File.Open("land.bin", FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                binaryFormatter.Serialize(stream, this);
            }
            catch (SerializationException)
            {
                throw;
            }
            finally
            {
                stream.Close();
            }

#if DEBUG
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            DebugWriter.WriteLine("<- Land::Persist: " + timeTaken.ToString(@"m\:ss\.fff"));
#endif
        }

        public void Load()
        {
#if DEBUG
            DebugWriter.WriteLine("-> Land::Load");
            var timer = new Stopwatch();
            timer.Start();
#endif

            Stream stream = File.Open("land.bin", FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                var land = (Land)binaryFormatter.Deserialize(stream);
                this.Naam = land.Naam;
                this.Id = land.Id;
                this.Regios = land.Regios;
            }
            catch (SerializationException)
            {
                throw;
            }
            finally
            {
                stream.Close();
            }

#if DEBUG
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            DebugWriter.WriteLine("<- Land::Load: " + timeTaken.ToString(@"m\:ss\.fff"));
#endif
        }
        #endregion
    }
}
