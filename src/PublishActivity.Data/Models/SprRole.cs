using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class SprRole
{
    public int IdRole { get; set; }

    public string? NameRole { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<SprUser> SprUsers { get; set; } = new List<SprUser>();
}
