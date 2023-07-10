using System;
using System.Collections.Generic;

namespace PublishActivity.Data.Models;

public partial class Author
{
    public int Uid { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string? Country { get; set; }

    public string? JobName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? OfficeDepartKodOffice { get; set; }

    public string? TabNum { get; set; }

    public string? YearBirth { get; set; }

    public virtual OfficeDepart? OfficeDepartKodOfficeNavigation { get; set; }
}
