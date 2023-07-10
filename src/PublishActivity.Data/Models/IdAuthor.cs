using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class IdAuthor
{
    public int AuthorUid { get; set; }

    public int SprIdAuthorsIdIas { get; set; }

    public virtual Author AuthorU { get; set; } = null!;

    public virtual SprIdAuthor SprIdAuthorsIdIasNavigation { get; set; } = null!;
}
