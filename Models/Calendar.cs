using System;
using System.Collections.Generic;

namespace EmployeeDb.Models;

public partial class Calendar
{
    public int Id { get; set; }

    public DateTime DateActivity { get; set; }

    public string Activity { get; set; } = null!;

    public string EmployeeEnrolNumber { get; set; } = null!;

    public virtual Employee? EmployeeEnrolNumberNavigation { get; set; }
}
