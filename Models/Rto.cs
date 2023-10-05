using System;
using System.Collections.Generic;

namespace AmigoCars.Models;

public partial class Rto
{
    public string RegNo { get; set; } = null!;

    public string? Place { get; set; }

    public string State { get; set; } = null!;

    public int RtoId { get; set; }

    public virtual ICollection<CarDetail> CarDetails { get; set; } = new List<CarDetail>();
}
