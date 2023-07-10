using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class StructuralPart
{
    public int IdPart { get; set; }

    public int? IdLanguage { get; set; }

    public string NamePart { get; set; } = null!;

    public string? NumArticle { get; set; }

    public int? PageBg { get; set; }

    public int? PageEnd { get; set; }

    public int PageCount { get; set; }

    public string? UrlArt { get; set; }

    public DateTime? DateIns { get; set; }

    public int? UserIns { get; set; }

    public int? CopyId { get; set; }

    public DateTime? DateEdA { get; set; }

    public int? UserEdA { get; set; }

    public DateTime? DateExtractA { get; set; }

    public int EditionIdEdt { get; set; }

    public int SprStructureIdTypePart { get; set; }

    public virtual Edition EditionIdEdtNavigation { get; set; } = null!;

    public virtual Language? IdLanguageNavigation { get; set; }

    public virtual SprStructure SprStructureIdTypePartNavigation { get; set; } = null!;
}
