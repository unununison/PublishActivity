using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class AuthorPubl
{
    public string? AuthorsPartA { get; set; }

    public int StructuralPartIdPart { get; set; }

    public int AuthorUid { get; set; }

    public virtual Author AuthorU { get; set; } = null!;

    public virtual StructuralPart StructuralPartIdPartNavigation { get; set; } = null!;
}
