using PublishActivity.Data.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Reports
{
    public partial class Series
    {
        public Series()
        {
            Editions = new HashSet<Edition>();
        }

        public int Issn { get; set; }
        public string IssnO { get; set; }
        public int Volume { get; set; }
        public DateTime DareEdit { get; set; }
        public DateTime DateExtractJ { get; set; }
        public string Release { get; set; }
        public string Coverage { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<Edition> Editions { get; set; }
    }
}
