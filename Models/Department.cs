﻿using System;
using System.Collections.Generic;

namespace HRMSystemWebAPI.Models;

public partial class Department
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? LocationId { get; set; }
}
