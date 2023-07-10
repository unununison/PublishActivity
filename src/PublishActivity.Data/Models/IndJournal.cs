using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class IndJournal
{
    public int IdIndJ { get; set; }

    public string? NameIndJ { get; set; }

    public int AnalyticalBaseIdAbase { get; set; }

    public virtual AnalyticalBase AnalyticalBaseIdAbaseNavigation { get; set; } = null!;
}
