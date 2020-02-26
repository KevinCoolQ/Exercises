using System;
using System.Collections.Generic;

namespace Straten
{
    [Serializable]
    public class Provincie
    {
        #region Properties
        public int Id { get; set; }
        public string TaalCode { get; set; }
        public string Naam { get; set; }

        /// <summary>
        /// Parent
        /// </summary>
        public Regio Regio { get; set; }

        /// <summary>
        /// Children
        /// </summary>
        public SortedList<string, Gemeente> Gemeenten { get; set; } = new SortedList<string, Gemeente>();
        #endregion

        #region Methods
        #endregion
    }
}
