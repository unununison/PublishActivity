using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class AnalyticalBase
{
    public int IdAbase { get; set; }

    public string? NameAbase { get; set; }

    public virtual ICollection<IndArticle> IndArticles { get; set; } = new List<IndArticle>();

    public virtual ICollection<IndJournal> IndJournals { get; set; } = new List<IndJournal>();
}
