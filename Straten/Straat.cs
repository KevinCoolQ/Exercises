using System;

namespace Straten
{
    [Serializable]
    public class Straat
    {
        #region Properties
        public int Id { get; set; }
        public string Naam { get; set; }

        /// <summary>
        /// Parent
        /// </summary>
        public Gemeente Gemeente { get; set; }
        #endregion
    }
}
