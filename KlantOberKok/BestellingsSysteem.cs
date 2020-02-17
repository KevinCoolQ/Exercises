namespace KlantOberKok
{
    using System;

    public class BestellingsSysteem
    {
        public event EventHandler<BestelEventArgs> BestellingEvent;

        public void GeefBestellingIn(BestelEventArgs args)
        {
            /*
            if (_bestellingEvent != null)
                _bestellingEvent(this, args);
            */
            BestellingEvent?.Invoke(this, args);
        }
    }
}
