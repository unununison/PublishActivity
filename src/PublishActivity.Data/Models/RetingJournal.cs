using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class RetingJournal
{
    public decimal ValumeInd { get; set; }

    public string? SubjectArea { get; set; }

    public DateTime? DateEditJ { get; set; }

    public int? UserId { get; set; }

    public int IndJournalIdIndJ { get; set; }

    public int? IdEdt { get; set; }

    public string? YearJ { get; set; }

    public virtual Edition? IdEdtNavigation { get; set; }

    public virtual IndJournal IndJournalIdIndJNavigation { get; set; } = null!;
}
