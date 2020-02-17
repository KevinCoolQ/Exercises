namespace KlantOberKok
{
    using System;

    public class Bel
    {
        public event EventHandler<BestelEventArgs> RingEvent;

        public void Ring(BestelEventArgs args)
        {
            RingEvent?.Invoke(this, args);
        }
    }
}
