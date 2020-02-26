using System;
using System.Collections.Generic;

namespace Straten
{
    [Serializable]
    public class Gemeente
    {
        #region Properties
        public int Id { get; set; }
        public int NaamId { get; set; }
        public string TaalCode { get; set; }
        public string Naam { get; set; }

        /// <summary>
        /// Parent
        /// </summary>
        public Provincie Provincie { get; set; }

        /// <summary>        
        /// Children
        /// </summary>
        public SortedList<string, Straat> Straten { get; set; } = new SortedList<string, Straat>();
        #endregion
    }
}
