using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class SprThematic
{
    public int IdThematic { get; set; }

    public string? NameThematic { get; set; }

    public int IdHeading { get; set; }

    public virtual SprHeading IdHeadingNavigation { get; set; } = null!;
}
