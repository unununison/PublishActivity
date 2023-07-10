using PublishActivity.Data.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Reports
{
    public partial class Book
    {
        public Book()
        {
            Editions = new HashSet<Edition>();
        }

        public int Isbn { get; set; }
        public int Volume { get; set; }
        public string Note { get; set; }
        public DateTime DateEdit { get; set; }
        public DateTime DateExrtactB { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<Edition> Editions { get; set; }
    }
}
