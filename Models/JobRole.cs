using System;
using System.Collections.Generic;

namespace HRMSystemWebAPI.Models;

public partial class JobRole
{
    public int Id { get; set; }

    public string? TitleRole { get; set; }

    public string? Description { get; set; }

    public int? DepartmentId { get; set; }
}
