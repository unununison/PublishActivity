using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class TmpExport1
{
    public int IdExport { get; set; }

    public string? NameAuthorEn { get; set; }

    public string? NameAuthorRu { get; set; }

    public string? NameEdt { get; set; }

    public string? Year { get; set; }

    public string? Release { get; set; }

    public string? DoiEd { get; set; }

    public string? UrlIsi { get; set; }

    public string? NamePdo { get; set; }

    public string? NamePart { get; set; }

    public string? Issn { get; set; }

    public string? Isbn { get; set; }

    public string? LanguagePart { get; set; }

    public string? NameStruct { get; set; }

    public string? ValumeUia { get; set; }

    public string? PageCount { get; set; }

    public int? PageBg { get; set; }

    public int? PageEnd { get; set; }

    public int? ValumeIndA { get; set; }

    public string? NameAbase { get; set; }

    public DateTime? DataExport { get; set; }

    public DateTime? DataImport { get; set; }
}
