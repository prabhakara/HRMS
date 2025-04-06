using System;
using System.Collections.Generic;

namespace HRMSystemWebAPI.Models;

public partial class Location
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }
}
