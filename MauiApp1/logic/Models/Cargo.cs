using System;
using System.Collections.Generic;

namespace logic.Models;

public partial class Cargo
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public string? Name { get; set; }

    public string? Origin { get; set; }

    public string? Destination { get; set; }

    public string? Type { get; set; }

    public string? Weight { get; set; }

    public int? Price { get; set; }

    public int? CargoCode { get; set; }

    public string? Status { get; set; }

    public virtual Customer? Customer { get; set; }
}
