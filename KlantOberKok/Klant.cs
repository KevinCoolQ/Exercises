namespace KlantOberKok
{
    using System;

    /// <summary>
    /// Klant: bestelt een product bij ober 
    /// </summary>
    public class Klant
    {
        public string Naam { get; set; }

        public Klant(string naam)
        {
            Naam = naam;
        }

        public void Betaal(string product)
        {
            Console.WriteLine("Ik ben " + Naam + " en ik betaal: " + product);
        }

        public void Consumeer(string product)
        {
            Console.WriteLine("Ik ben " + Naam + " en ik speel binnen: " + product);
        }

        public void Bestel(Ober ober, string product)
        {
            if (ober == null || string.IsNullOrEmpty(product)) return; // preconditie

            ober.BrengBestelling(this, product);
        }
    }
}
