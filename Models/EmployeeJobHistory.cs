using System;
using System.Collections.Generic;

namespace HRMSystemWebAPI.Models;

public partial class EmployeeJobHistory
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public int? Manager { get; set; }

    public int? JobRoleId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool? Status { get; set; }

    public string? Comments { get; set; }
}
