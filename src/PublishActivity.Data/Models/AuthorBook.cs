using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class AuthorBook
{
    public string? AuthorPartB { get; set; }

    public int EdnIdEdt { get; set; }

    public int AuthorUid { get; set; }

    public virtual Author AuthorU { get; set; } = null!;

    public virtual Edition EdnIdEdtNavigation { get; set; } = null!;
}
