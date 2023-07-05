using System;
using System.Collections.Generic;

namespace EmployeeDb.Models;

public partial class Employee
{
    public string EmployeeEnrolNumber { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? EmployeeDepartment { get; set; }

    public short? Age { get; set; }

    public string EmployeeJob { get; set; } = null!;

    public virtual ICollection<Calendar> Calendars { get; set; } = new List<Calendar>();

    public virtual ICollection<Hobby> Hobbies { get; set; } = new List<Hobby>();
}
