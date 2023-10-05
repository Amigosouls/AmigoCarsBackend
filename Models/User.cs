using System;
using System.Collections.Generic;

namespace AmigoCars.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? UserEmail { get; set; }

    public string? Password { get; set; }

    public int? RoleId { get; set; }

    public int? UserAddress { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? LastLogin { get; set; }

    public string? Img { get; set; }

    public virtual ICollection<CarDetail> CarDetails { get; set; } = new List<CarDetail>();

    public virtual Role? Role { get; set; }

    public virtual Address? UserAddressNavigation { get; set; }
}
