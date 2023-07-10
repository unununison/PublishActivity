using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class LevelEdition
{
    public int IdEdition { get; set; }

    public string? NameLevEdition { get; set; }

    public virtual ICollection<Edition> Editions { get; set; } = new List<Edition>();
}
