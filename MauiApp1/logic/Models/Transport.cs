using System;
using System.Collections.Generic;

namespace logic.Models;

public partial class Transport
{
    public int Id { get; set; }

    public int? IdTrakera { get; set; }

    public string? GosNumber { get; set; }

    public string? Model { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();
}
