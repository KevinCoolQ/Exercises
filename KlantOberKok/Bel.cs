namespace KlantOberKok
{
    using System;

    /// <summary>
    /// Bel: kok duwt op bel, event loopt af, ober is hierop geabonneerd en reageert
    /// </summary>
    public class Bel
    {
        #region Events
        public event EventHandler<BestelEventArgs> RingEvent;
        #endregion

        #region Methods
        public void Ring(BestelEventArgs args)
        {
            RingEvent?.Invoke(this, args);
        }
        #endregion
    }
}
