using Straten;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace StratenExport.Providers
{
    class LandProvider
    {
        #region Fields
        private Land _land;
        #endregion

        #region Ctor
        public LandProvider(Land land)
        {
            _land = land;
        }
        #endregion

        #region Methods
        public void Load()
        {
#if DEBUG
            DebugWriter.WriteLine("-> LandProvider::Load");
            var timer = new Stopwatch();
            timer.Start();
#endif

            Stream stream = File.Open(Config.StoragePath + "/land.bin", FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                var land = (Land)binaryFormatter.Deserialize(stream);
                _land.Naam = land.Naam;
                _land.Id = land.Id;
                _land.Regios = land.Regios;
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
            DebugWriter.WriteLine("<- LandProvider::Load: " + timeTaken.ToString(@"m\:ss\.fff"));
#endif
        }
        #endregion
    }
}
