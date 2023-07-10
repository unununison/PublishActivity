using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class SprUser
{
    public int IdUsers { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? Patronymic { get; set; }

    public string LoginUser { get; set; } = null!;

    public string PwdUser { get; set; } = null!;

    public string? Note { get; set; }

    public int IdRole { get; set; }

    public int? Uid { get; set; }

    public virtual SprRole IdRoleNavigation { get; set; } = null!;
}
