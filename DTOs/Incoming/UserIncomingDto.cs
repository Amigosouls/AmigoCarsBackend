namespace AmigoCars.DTOs.Incoming
{
    public class UserLoginDto
    {
        public string? UserEmail { get; set; }
        public string? Password { get; set; }
    }
    public class GetUserRole
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
    }
    public class GetUserAddressDto
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

    }
    public class GetUserDetailsDto
    {

        public string? UserName { get; set; }

        public string? UserEmail { get; set; }

        public string? Password { get; set; }

        public int? RoleId { get; set; }

        public int? UserAddress { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? LastLogin { get; set; }

        public string? Img { get; set; }

    }
}
