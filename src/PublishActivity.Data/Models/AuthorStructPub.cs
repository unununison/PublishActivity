using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class AuthorStructPub
{
    public int Uid { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string? OfficeDepartKodOffice { get; set; }

    public string NamePart { get; set; } = null!;
}
