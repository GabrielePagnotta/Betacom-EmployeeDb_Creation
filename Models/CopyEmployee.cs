using System;
using System.Collections.Generic;

namespace EmployeeDb.Models;

public partial class CopyEmployee
{
    public string Name { get; set; } = null!;

    public string EmployeeEnrolNumber { get; set; } = null!;

    public string EmployeeJob { get; set; } = null!;
}
