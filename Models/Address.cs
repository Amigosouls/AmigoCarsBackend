using System;
using System.Collections.Generic;

namespace AmigoCars.Models;

public partial class Address
{
    public string CircleName { get; set; } = null!;

    public string RegionName { get; set; } = null!;

    public string DivisionName { get; set; } = null!;

    public string OfficeName { get; set; } = null!;

    public int Pincode { get; set; }

    public string OfficeType { get; set; } = null!;

    public string Delivery { get; set; } = null!;

    public string District { get; set; } = null!;

    public string StateName { get; set; } = null!;

    public int Id { get; set; }

    public virtual ICollection<CarDetail> CarDetails { get; set; } = new List<CarDetail>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
