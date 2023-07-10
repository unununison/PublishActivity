using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class Aut
{
    public int IdAut { get; set; }

    public string? Fam { get; set; }

    public string? Nam1 { get; set; }

    public string? Nam2 { get; set; }

    public int? IdExp { get; set; }
}
