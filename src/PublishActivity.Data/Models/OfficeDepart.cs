using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class OfficeDepart
{
    public string KodOffice { get; set; } = null!;

    public string? KodParent { get; set; }

    public string? NameOffice { get; set; }

    public int? TypeOffice { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();
}
