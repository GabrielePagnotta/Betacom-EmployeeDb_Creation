using System;
using System.Collections.Generic;

namespace EmployeeDb.Models;

public partial class ViewEmployee
{
    public string EmployeeEnrolNumber { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? EmployeeDepartment { get; set; }

    public short? Age { get; set; }

    public string EmployeeJob { get; set; } = null!;

    public int IdCal { get; set; }

    public string Activity { get; set; } = null!;

    public DateTime DateActivity { get; set; }

    public short? IdHobby { get; set; }

    public string? HobbyDescription { get; set; }

    public DateTime? InsertDate { get; set; }
}
