using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class UiaArticle
{
    public string ValumeUia { get; set; } = null!;

    public int StructuralPartIdPart { get; set; }

    public int SprIdEditionIdUia { get; set; }

    public virtual SprIdEdition SprIdEditionIdUiaNavigation { get; set; } = null!;

    public virtual StructuralPart StructuralPartIdPartNavigation { get; set; } = null!;
}
