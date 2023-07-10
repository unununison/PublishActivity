using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class SprStructure
{
    public int IdTypePart { get; set; }

    public string? NamePart { get; set; }

    public string? NamePart1 { get; set; }

    public virtual ICollection<StructuralPart> StructuralParts { get; set; } = new List<StructuralPart>();
}
