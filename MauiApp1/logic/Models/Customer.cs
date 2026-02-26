using System;
using System.Collections.Generic;

namespace logic.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? CompanyName { get; set; }

    public string? Contact { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Cargo> Cargos { get; set; } = new List<Cargo>();
}
