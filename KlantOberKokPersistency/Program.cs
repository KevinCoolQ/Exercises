namespace KlantOberKok
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            Klant klant1 = new Klant("Piet");
            Klant klant2 = new Klant("Jef");
            context.Klanten.Add(klant1);
            context.Klanten.Add(klant2);
            BestellingsSysteem bestellingsSysteem = new BestellingsSysteem();
            Bel bel = new Bel();
            Ober ober = new Ober("Jan")
            {
                BestellingsSysteem = bestellingsSysteem,
                Bel = bel,
            };
            context.Obers.Add(ober);

            // kok en ober weten niet van elkaar!
            Kok kok = new Kok("Marie")
            {
                BestellingsSysteem = bestellingsSysteem,
                Bel = bel,
            };
            context.Koks.Add(kok);

            klant1.Bestel(ober, "Hoegaarden");
            klant2.Bestel(ober, "Koffie");

            context.Save();

            Console.ReadKey();
        }
    }
}
