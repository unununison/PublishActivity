using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class ViewEdition
{
    public int IdEdt { get; set; }

    public string NameEdt { get; set; } = null!;

    public string Year { get; set; } = null!;

    public string? Town { get; set; }

    public string? Region { get; set; }

    public string? Regularity { get; set; }

    public string? TypeAccess { get; set; }

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

    public string? NameLang { get; set; }

    public string? NameNlnform { get; set; }

    public string? NameLevEdition { get; set; }

    public string? NamePdo { get; set; }

    public string? PublOffTown { get; set; }

    public string? PublOffRegion { get; set; }
}
