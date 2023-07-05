using System;
using System.Collections.Generic;

namespace EmployeeDb.Models;

public partial class Copyemp
{
    public string EmployeeEnrolNumber { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? EmployeeDepartment { get; set; }

    public short? Age { get; set; }

    public string EmployeeJob { get; set; } = null!;
}
