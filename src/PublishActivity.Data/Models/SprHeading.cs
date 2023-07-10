using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class SprHeading
{
    public int IdHeading { get; set; }

    public string? NameHeading { get; set; }

    public virtual ICollection<SprThematic> SprThematics { get; set; } = new List<SprThematic>();
}
