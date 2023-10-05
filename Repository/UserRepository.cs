using AmigoCars.Contracts;
using AmigoCars.DTOs.Incoming;
using AmigoCars.DTOs.Outgoing;
using AmigoCars.Exceptions;
using AmigoCars.Models;
using AmigoCars.Resources;
using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AmigoCars.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AmigoCarsContext _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public UserRepository(AmigoCarsContext context, IConfiguration config, IMapper mapper)
        {
            this._context = context;
            this._configuration = config;
            this._mapper = mapper;
        }

        public async Task<UsersOutgoingDto> GetUserAsync(string? userEmail)
        {
            if (userEmail == null) return null;
            var user = await this._context.Users.FirstOrDefaultAsync(x=>x.UserEmail == userEmail);
            if (user != null)
            {
                var userRoles = await _context.Roles.FirstOrDefaultAsync(x => x.RoleId == user.RoleId);
                var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == user.UserAddress);
                var source = _mapper.Map<UsersOutgoingDto>(user);
                if (userRoles != null && address != null)
                {
                    source.RoleName = userRoles.RoleName;
                    source.CircleName = address.CircleName;
                    source.RegionName = address.RegionName;
                    source.DivisionName = address.DivisionName;
                    source.OfficeName = address.OfficeName;
                    source.Pincode = address.Pincode;
                    source.OfficeType = address.OfficeType;
                    source.Delivery = address.Delivery;
                    source.District = address.District;
                    source.StateName = address.StateName;
                }
                return source;
            }
            else throw new NotFoundException("The User is not found");
          
            
            
        }

        public async Task<Success> CreateUsersAsync([FromBody] User user)
        {
            string msg = "";


            if (user != null)
            {

                if (await CheckEmailExistAsync(user.UserEmail))
                {
                    msg = "The user Email already Exists";
                    throw new BadRequestException(msg);
                }
                user.Password = Hasher.HashPassword(user.Password);
                var userToSave = _mapper.Map<User>(user);
                await this._context.AddAsync(user);
                await this._context.SaveChangesAsync();
            }
            return new Success { StatusCode = 200, Message = "User Registered Successfully" };
        }
        public async Task DeleteUserAsync(int userId)
        {
            var deletedUser = await this._context.Users.FindAsync();
            if (deletedUser == null)
            {
                throw new NotFoundException($"The User is not found with id {userId}");
            }
            this._context.Set<User>().Remove(deletedUser);
            await this._context.SaveChangesAsync();
        }

        public async Task UpdateUsersAsync(User user)
        {
            _context.Update(user);
            await this._context.SaveChangesAsync();
        }



        public async Task<List<User>> GetAllUsersAsync()
        {
            return await this._context.Set<User>().ToListAsync();
        }

        public async Task<TokenDetailsDto> AuthenticateUser([FromBody] UserLoginDto user)
        {
            if (user == null)
                throw new BadRequestException("The data passed to the request is null!");
            var loggedUser = await _context.Users.FirstOrDefaultAsync(x => x.UserEmail == user.UserEmail);
            if (loggedUser == null)
            {
                throw new NotFoundException("The Username doesn't Exist");
            }
            if (!Hasher.VerifyPassword(user.Password, loggedUser.Password))
            {
                throw new NotFoundException("The Username or password is incorrect!");
            }

            var userRoles = await _context.Roles.FirstOrDefaultAsync(x => x.RoleId == loggedUser.RoleId);
            var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == loggedUser.UserAddress);
            var source = _mapper.Map<UsersOutgoingDto>(loggedUser);
            if (userRoles != null && address != null)
            {
                source.RoleName = userRoles.RoleName;
                source.CircleName = address.CircleName;
                source.RegionName = address.RegionName;
                source.DivisionName = address.DivisionName;
                source.OfficeName = address.OfficeName;
                source.Pincode = address.Pincode;
                source.OfficeType = address.OfficeType;
                source.Delivery = address.Delivery;
                source.District = address.District;
                source.StateName = address.StateName;
                source.Token = GenerateAsync(source);
            }

            return new TokenDetailsDto { Token= GenerateAsync(source),Message ="Login Successfull", Email=source.UserEmail};
        }

        public string GenerateAsync(UsersOutgoingDto user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserName ),
                new Claim(ClaimTypes.Email,user.UserEmail ),
                new Claim(ClaimTypes.Role,user.RoleName ),
                new Claim(ClaimTypes.StateOrProvince,user.StateName ),
                new Claim(ClaimTypes.UserData,user.Img)
            });
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
        public async Task<bool> CheckEmailExistAsync(string userEmail)
        => await _context.Users.AnyAsync(x => x.UserEmail == userEmail);


    }
}
