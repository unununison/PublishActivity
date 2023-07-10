using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class IndArticle
{
    public int IdIndPrt { get; set; }

    public string? NameIndPrt { get; set; }

    public int AnalyticalBaseIdAbase { get; set; }

    public virtual AnalyticalBase AnalyticalBaseIdAbaseNavigation { get; set; } = null!;
}
