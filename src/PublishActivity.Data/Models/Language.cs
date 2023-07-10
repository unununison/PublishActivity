using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class Language
{
    public int IdLanguage { get; set; }

    public string? NameLang { get; set; }

    public string? NameLang1 { get; set; }

    public virtual ICollection<Edition> Editions { get; set; } = new List<Edition>();

    public virtual ICollection<StructuralPart> StructuralParts { get; set; } = new List<StructuralPart>();
}
