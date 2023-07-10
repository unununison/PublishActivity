using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class AutStructurPart
{
    public int Uid { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string? JobName { get; set; }

    public string? OfficeDepartKodOffice { get; set; }

    public int AuthorUid { get; set; }

    public string? NameOffice { get; set; }

    public int StructuralPartIdPart { get; set; }

    public string NamePart { get; set; } = null!;

    public int EditionIdEdt { get; set; }
}
