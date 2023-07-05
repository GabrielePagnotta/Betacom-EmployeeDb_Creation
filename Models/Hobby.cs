using System;
using System.Collections.Generic;

namespace EmployeeDb.Models;

public partial class Hobby
{
    public short Id { get; set; }

    public string EmployeeEnrolNumber { get; set; } = null!;

    public DateTime? InsertDate { get; set; }

    public string? HobbyDescription { get; set; }

    public virtual Employee EmployeeEnrolNumberNavigation { get; set; } = null!;
}
