namespace AmigoCars.DTOs.Outgoing
{
    public class UsersOutgoingDto
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public DateTime? LastLogin { get; set; }
        public string? Img { get; set; }
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? CircleName { get; set; }
        public string? RegionName { get; set; } 
        public string? DivisionName { get; set; } 
        public string? OfficeName { get; set; } 
        public int Pincode { get; set; }
        public string? OfficeType { get; set; }     
        public string? Delivery { get; set; }   
        public string? District { get; set; }   
        public string? StateName { get; set; }  
        public string? Token { get; set; }  
    }
    public class UserClaimsDto
    {
        public string? UserName { get; set; }
        public string? Role { get; set; }
        public string? UserEmail { get; set; }
        public string? StateName { get; set; }
    }
    public class TokenDetailsDto
    {
        public string? Token { get; set; }
        public string? Message { get; set; }
        public string? Email {  get; set; }
    }
}
    