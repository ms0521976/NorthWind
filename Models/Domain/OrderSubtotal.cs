using System;
using System.Collections.Generic;

namespace NorthWind.Models.Domain;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
