
using Microsoft.AspNetCore.Mvc;
using AmigoCars.Models;
using AmigoCars.Repository;
using AmigoCars.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using AmigoCars.DTOs.Incoming;
using AmigoCars.DTOs.Outgoing;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AmigoCars.Controllers
{
    [Route("api/Users")]
    [ApiController]
    [EnableCors]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        

        public UsersController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
            
        }

        [HttpGet("LoggedUser")]
        [Authorize(Roles ="User,Admin")]
        public async Task<ActionResult<UsersOutgoingDto>> GetLoggedUser(string email)
        {
            var userResult = await this._userRepository.GetUserAsync(email);
            return userResult;
        } 

        // GET: api/Users
        [HttpPost("GetUsers")]
        public async Task<ActionResult<TokenDetailsDto>> AuthenticateUser([FromBody] UserLoginDto user)
        {
            
            var loggedUser =  await this._userRepository.AuthenticateUser(user);
            
            return loggedUser;
        }
        [HttpPost("RegisterUser")]
        public async Task<Success> RegisterUser([FromBody] User user)
        {
            var response = await _userRepository.CreateUsersAsync(user);
            return response;
        }
        //[HttpGet("Admins")]
        //[Authorize(Roles ="Admin")]
        //public IActionResult AdminEndPoint()
        //{
        //    var currentUser = GetCurrentUser();
        //    return Ok($"Hi {currentUser.UserName}");
        //}
        //private UserClaimsDto GetCurrentUser()
        //{
        //    var identity = HttpContext.User.Identity as ClaimsIdentity;
        //    if(identity != null) 
        //    {
        //        var userClaims = identity.Claims;
        //        return new UserClaimsDto
        //        {
        //            UserName = userClaims.FirstOrDefault(o=>o.Type==ClaimTypes.NameIdentifier)?.Value,
        //            UserEmail = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
        //            Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,
        //            StateName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.StateOrProvince)?.Value
                    
        //        };
        //    }
        //    return null;
        //}
    }
}
