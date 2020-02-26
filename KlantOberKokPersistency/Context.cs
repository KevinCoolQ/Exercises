using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace KlantOberKok
{
    [Serializable]
    class Context
    {
        public List<Kok> Koks { get; set; }
        public List<Klant> Klanten { get; set; }
        public List<Ober> Obers { get; set; }

        public Context()
        {
            Koks = new List<Kok>();
            Klanten = new List<Klant>();
            Obers = new List<Ober>();
        }
        internal void Save()
        {
            Stream stream = File.Open("context.bin", FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                binaryFormatter.Serialize(stream, this);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine("Exception when serializing: " + ex.Message);
                throw;
            }
            finally
            {
                stream.Close();
            }
        }
    }
}
