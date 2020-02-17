namespace KlantOberKok
{
    using System.Collections.Generic;
    using System.Linq;

    public class Ober
    {
        private List<Klant> _klanten = new List<Klant>();

        public string Naam { get; set; }

        public BestellingsSysteem BestellingsSysteem { get; set; }

        private Bel _bel;

        public Bel Bel
        {
            get
            {
                return this._bel;
            }

            set
            {
                if (this._bel != null) this._bel.RingEvent -= this.BelGehoord;
                this._bel = value;
                this._bel.RingEvent += this.BelGehoord;
            }
        }

        public Ober(string name)
        {
            this.Naam = name;
        }

        public void BrengBestelling(Klant klant, string product)
        {
            if (klant == null || string.IsNullOrEmpty(product)) return; // preconditie

            if (!_klanten.Contains(klant))
                _klanten.Add(klant);
            BestellingsSysteem.GeefBestellingIn(new BestelEventArgs { Klant = klant.Naam, Product = product });
        }

        private void BelGehoord(object sender, BestelEventArgs args)
        {
            // LINQ:
            var klant = this._klanten.Where(k => k.Naam == args.Klant).FirstOrDefault(); // EERSTE OF NULL
            if (klant == null) return;
            klant.Betaal(args.Product);
            klant.Consumeer(args.Product);
        }
    }
}
