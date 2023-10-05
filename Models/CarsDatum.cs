using System;
using System.Collections.Generic;

namespace AmigoCars.Models;

public partial class CarsDatum
{
    public int CarId { get; set; }

    public string? Make { get; set; }

    public string? Model { get; set; }

    public string? Variant { get; set; }

    public double? Price { get; set; }

    public string? FuelType { get; set; }
}
