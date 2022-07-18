using BookStore.Domain.Helper;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public void Dispose()
        {
            _userRepository?.Dispose();
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }
        public async Task<string> GetUser(string userName, string password)
        {
            var result = await _userRepository.GetUser(userName, password);
            if (result is null)
            {
                return null;
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("Id", result.Id.ToString()),
                new Claim("Email", result.Email),
                new Claim("Phone", result.Phone)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
            var tokenReturn = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenReturn;
        }

        public async Task<bool> Register(User user)
        {
            if(user is null)
            {
                return false;
            }
            var newUser = new User{ 
                Username = user.Username,
                Password = HashHelper.SHA256(user.Password),
                Email = user.Email,
                Phone = user.Phone,
                DateOfBirth = user.DateOfBirth,
                IsActive = true,
                Level = 0
            };
            await _userRepository.Add(newUser);
            await _userRepository.SaveChanges();
            return true;
        }

    }
}
