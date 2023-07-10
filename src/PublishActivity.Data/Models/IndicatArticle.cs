using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class IndicatArticle
{
    public int ValumeIndA { get; set; }

    public DateTime? DateEditA { get; set; }

    public int? UserId { get; set; }

    public int StructuralPartIdPart { get; set; }

    public int IndArticlesIdIndPrt { get; set; }

    public virtual IndArticle IndArticlesIdIndPrtNavigation { get; set; } = null!;

    public virtual StructuralPart StructuralPartIdPartNavigation { get; set; } = null!;
}
