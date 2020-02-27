using System;
using System.Collections.Generic;

namespace Straten
{
    [Serializable]
    public class Regio
    {
        #region Properties
        public int Id { get; set; }
        public string Naam { get; set; }

        /// <summary>
        /// Parent: geen copie!
        /// </summary>
        public Land Land { get; set; }

        /// <summary>
        /// Children
        /// </summary>

        public SortedList<string, Provincie> Provincies { get; set; } = new SortedList<string, Provincie>();
        #endregion
    }
}
