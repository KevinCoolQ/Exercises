namespace KlantOberKok
{
    using System;

    [Serializable]
    public class BestellingsSysteem
    {
        #region Events
        public event EventHandler<BestelEventArgs> BestellingEvent;
        #endregion

        #region Methods
        public void GeefBestellingIn(BestelEventArgs args)
        {
            /*
            if (_bestellingEvent != null)
                _bestellingEvent(this, args);
            */
            BestellingEvent?.Invoke(this, args);
        }
        #endregion
    }
}
