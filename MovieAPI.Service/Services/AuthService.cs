using MovieAPI.Data.Repositories;
using MovieAPI.Service.DTOs;
using MovieAPI.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using MovieAPI.Service.Exceptions;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace MovieAPI.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repo;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository repo, IPasswordHasher<User> passwordHasher, IConfiguration configuration)
        {
            _passwordHasher = passwordHasher;
            _repo = repo;
            _configuration = configuration;
        }
        public async Task<LoginResponseDto> LoginAsync(LoginDto dto)
        {
            User? user = await _repo.GetUserByEmailAsync(dto.Email);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }
            

            PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                throw new UnauthorizedException("Invalid email or password.");
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    user.Id.ToString()
                ),

                new Claim(
                    ClaimTypes.Name,
                    user.Username
                ),

                new Claim(
                    ClaimTypes.Email,
                    user.Email
                )
            };

            string jwtkey = _configuration["Jwt:Key"]!;
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtkey)
            );

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            double expireMinutes = double.Parse(
                _configuration["Jwt:ExpireMinutes"]!
            );

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expireMinutes),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            string tokenString = tokenHandler.WriteToken(token);

            return new LoginResponseDto
            {
                Token = tokenString,
                UserId = user.Id,
                Username = user.Username,
                Email = user.Email
            };
        }
    }
}