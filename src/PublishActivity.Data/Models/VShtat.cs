using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class VShtat
{
    public int Id { get; set; }

    public string? ShifrSotr { get; set; }

    public string? Fio { get; set; }

    public string? Fam { get; set; }

    public string? Nam1 { get; set; }

    public string? Nam2 { get; set; }

    public string? Academic { get; set; }

    public string? Scstatus { get; set; }

    public string? ShtatName { get; set; }

    public DateTime? DateStart { get; set; }

    public double? Salary { get; set; }

    public string? KodDep { get; set; }

    public string? NameDep { get; set; }

    public string? KodAGr { get; set; }

    public string? NameGr { get; set; }

    public bool? FlagOsn { get; set; }

    public bool? FlagIn { get; set; }

    public bool? FlagOut { get; set; }

    public string? MgtucategoryCode { get; set; }

    public string? Mgtucategory { get; set; }

    public string? Sex { get; set; }

    public string? Kval { get; set; }

    public string? YearBirth { get; set; }
}
