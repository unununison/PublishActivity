using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class Edition
{
    public int IdEdt { get; set; }

    public int EdnIdPbo { get; set; }

    public string NameEdt { get; set; } = null!;

    public string Year { get; set; } = null!;

    public string? Town { get; set; }

    public string? Region { get; set; }

    public string? Regularity { get; set; }

    public string? TypeAccess { get; set; }

    public int? EdnIdLanguage { get; set; }

    public int? SprFormatInfoTypeEd { get; set; }

    public int? IdEdition { get; set; }

    public string EdnTypeEd { get; set; } = null!;

    public string? DoiEd { get; set; }

    public string? UrlIsi { get; set; }

    public string? Issn { get; set; }

    public string? IssnO { get; set; }

    public string? Isbn { get; set; }

    public string? Release { get; set; }

    public int? Volume { get; set; }

    public string? Coverage { get; set; }

    public string? Note { get; set; }

    public DateTime? DateEdit { get; set; }

    public string? UserId { get; set; }

    public DateTime? DateExtract { get; set; }

    public virtual Language? EdnIdLanguageNavigation { get; set; }

    public virtual PublishingOffice EdnIdPboNavigation { get; set; } = null!;

    public virtual LevelEdition? IdEditionNavigation { get; set; }

    public virtual SprFormatInfo? SprFormatInfoTypeEdNavigation { get; set; }

    public virtual ICollection<StructuralPart> StructuralParts { get; set; } = new List<StructuralPart>();
}
