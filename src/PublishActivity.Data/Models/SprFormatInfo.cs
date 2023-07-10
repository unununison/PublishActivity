using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class SprFormatInfo
{
    public int TypeEd { get; set; }

    public string? NameNlnform { get; set; }

    public virtual ICollection<Edition> Editions { get; set; } = new List<Edition>();
}
