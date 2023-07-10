using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class CategoryEdit
{
    public string? KodHeading { get; set; }

    public string? NameArea { get; set; }

    public int EditionIdEdt { get; set; }

    public int SprHeadingIdHeading { get; set; }

    public virtual Edition EditionIdEdtNavigation { get; set; } = null!;

    public virtual SprHeading SprHeadingIdHeadingNavigation { get; set; } = null!;
}
