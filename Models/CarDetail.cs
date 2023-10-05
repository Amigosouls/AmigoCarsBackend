using System;
using System.Collections.Generic;

namespace AmigoCars.Models;

public partial class CarDetail
{
    public int CarId { get; set; }

    public string? RegistrationNo { get; set; }

    public string? Brand { get; set; }

    public int? Year { get; set; }

    public string? Model { get; set; }

    public string? FuelType { get; set; }

    public string? Transmission { get; set; }

    public int? RtoCircle { get; set; }

    public long? KmDriven { get; set; }

    public int? CarLocation { get; set; }

    public int? SellerId { get; set; }

    public string? CarImg { get; set; }

    public decimal? Price { get; set; }

    public virtual Address? CarLocationNavigation { get; set; }

    public virtual Rto? RtoCircleNavigation { get; set; }

    public virtual User? Seller { get; set; }
}
