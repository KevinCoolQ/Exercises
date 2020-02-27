using System;
using System.Collections.Generic;

namespace Straten
{
    [Serializable]
    public class Land
    {
        #region Properties
        public int Id { get; set; }
        public string Naam { get; set; }
        public string TaalCode { get; set; }

        /// <summary>
        /// Children
        /// </summary>
        public SortedList<string, Regio> Regios { get; set; } = new SortedList<string, Regio>();
        #endregion
    }
}
