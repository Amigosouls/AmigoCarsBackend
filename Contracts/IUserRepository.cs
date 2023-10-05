using AmigoCars.DTOs.Incoming;
using AmigoCars.DTOs.Outgoing;
using AmigoCars.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmigoCars.Contracts
{
    public interface IUserRepository
    {
        Task<UsersOutgoingDto> GetUserAsync(string? userEmail);
        Task<List<User>> GetAllUsersAsync();
        Task<Success> CreateUsersAsync ([FromBody] User user);
        Task<TokenDetailsDto> AuthenticateUser([FromBody] UserLoginDto user);
        Task UpdateUsersAsync (User user);
        Task DeleteUserAsync (int userId);
        string GenerateAsync(UsersOutgoingDto user);
        
    }
}
