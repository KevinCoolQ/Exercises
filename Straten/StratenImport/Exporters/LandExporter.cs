using Straten;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace StratenImport.Exporters
{
    public class LandExporter
    {
        #region Fields
        private Land _land;
        #endregion

        #region Ctor
        public LandExporter(Land land)
        {
            _land = land;
        }
        #endregion

        #region Methods
        public void Persist()
        {
#if DEBUG
            DebugWriter.WriteLine("-> LandExporter::Persist");
            var timer = new Stopwatch();
            timer.Start();
#endif

            Stream stream = File.Open(Config.StoragePath + "/land.bin", FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                binaryFormatter.Serialize(stream, _land);
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
            DebugWriter.WriteLine("<- LandExporter::Persist: " + timeTaken.ToString(@"m\:ss\.fff"));
#endif
        }
        #endregion
    }
}
