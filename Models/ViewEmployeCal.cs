using System;
using System.Collections.Generic;

namespace EmployeeDb.Models;

public partial class ViewEmployeCal
{
    public string EmployeeEnrolNumber { get; set; } = null!;

    public string Name { get; set; } = null!;

    public short? Age { get; set; }

    public string Activity { get; set; } = null!;
}
