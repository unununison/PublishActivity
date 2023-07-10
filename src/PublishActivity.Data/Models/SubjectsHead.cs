using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class SubjectsHead
{
    public int StructuralPartIdPart { get; set; }

    public int IdThematic { get; set; }

    public virtual SprThematic IdThematicNavigation { get; set; } = null!;

    public virtual StructuralPart StructuralPartIdPartNavigation { get; set; } = null!;
}
