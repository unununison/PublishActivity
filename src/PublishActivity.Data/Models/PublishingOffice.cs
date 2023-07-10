using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class PublishingOffice
{
    public int IdPbo { get; set; }

    public string? NamePdo { get; set; }

    public string? Town { get; set; }

    public string? Region { get; set; }

    public virtual ICollection<Edition> Editions { get; set; } = new List<Edition>();
}
