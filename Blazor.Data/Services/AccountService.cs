﻿using Blazor.Data.Interfaces;
using Blazor.Data.Models;
using Blazor.Data.Responses;
using Blazor.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blazor.Data.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _AppUserService;
        private readonly IAppRoleService _AppRoleService;
        private readonly IConfiguration _configuration;

        public AccountService(
            UserManager<AppUser> userManager,
            IAppUserService AppUserService,
            IAppRoleService AppRoleService,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _AppUserService = AppUserService;
            _AppRoleService = AppRoleService;
            _configuration = configuration;
        }

        public async Task<bool> CheckPasswordAsync(AppUser user, string password)
        {
            var result = await _userManager.CheckPasswordAsync(user, password);
            return result;
        }

        public async Task<JwtTokenResponse> GenerateToken(AppUser user)
        {
            var jwtSettings = new JwtTokenConfig
            {
                Secret = _configuration["JwtToken:SecretKey"],
                Issuer = _configuration["JwtToken:Issuer"],
                Audience = _configuration["JwtToken:Audience"],
            };
            var key = Encoding.UTF8.GetBytes(jwtSettings.Secret);

            var userRole = await _AppUserService.GetUserRoleAsync(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role,""),
                new Claim("UserId", user.Id.ToString()),
                new Claim("UserFullName", $"{user.FirstName} {user.LastName}"),
            };

            var expiresIn = DateTime.Now.AddDays(30);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = jwtSettings.Audience,
                Issuer = jwtSettings.Issuer,
                Expires = expiresIn,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);

            return new JwtTokenResponse
            {
                access_token = new JwtSecurityTokenHandler().WriteToken(token),
                expires_in = (int)(expiresIn - DateTime.Now).TotalMinutes,
                Successful = true
            };
        }

        public async Task<JwtTokenResponse> LoginAsync(LoginCommand login)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == login.Email);
            if (user == null)
            {
                throw new Exception("Email / password incorrect");
            }
            var passwordValid = await CheckPasswordAsync(user, login.Password);
            if (passwordValid == false)
            {
                throw new Exception("Email / password incorrect");
            }

            return await GenerateToken(user);
        }

        public async Task<JwtTokenResponse> RegisterAsync(RegisterCommand register)
        {
            var existUser = _userManager.Users.SingleOrDefault(u => u.UserName == register.Email);
            if (existUser == null)
            {
                AppUser newUser = new AppUser
                {
                    UserName = register.Email,
                    Email = register.Email,
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                };

                if (!register.Password.Equals(register.ConfirmPassword))
                {
                    throw new Exception("Passwords do not match");
                }

                await _userManager.CreateAsync(newUser, register.Password);
                var role = _AppRoleService.GetDefaultRole();
                await _AppRoleService.SetUserRoleAsync(newUser, role.Name);
                return await GenerateToken(newUser);
            }
            else
            {
                throw new Exception("The user with the unique identifier already exists");
            }
        }
    }
}
