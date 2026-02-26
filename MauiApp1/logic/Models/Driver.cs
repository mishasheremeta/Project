using System;
using System.Collections.Generic;

namespace logic.Models;

public partial class Driver
{
    public int Id { get; set; }

    public string? Fullname { get; set; }

    public string? Phone { get; set; }

    public string? Status { get; set; }

    public int? TransportId { get; set; }

    public virtual Transport? Transport { get; set; }
}
