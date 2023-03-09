using System;
using System.Collections.Generic;

namespace WebApplicationPAS.Models;

public partial class Customeraccount
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public DateOnly Birthday { get; set; }
}
