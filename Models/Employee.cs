using System;
using System.Collections.Generic;

namespace HRMSystemWebAPI.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public bool? Gender { get; set; }

    public string? Address { get; set; }

    public bool? Status { get; set; }
}
