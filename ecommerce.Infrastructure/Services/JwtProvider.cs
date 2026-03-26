using ecommerce.Application.DTOs.Account;
using ecommerce.Application.Services;
using ecommerce.Domain.Entities.Users;
using ecommerce.Infrastructure.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ecommerce.Infrastructure.Services
{
    public class JwtProvider(
        UserManager<UserApp> userManager,
        IOptions<JwtOptions> jwtOptions) : IJwtProvider
    {
        public async Task<LoginCommandResponse> CreateToke(UserApp userApp)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, userApp.Id),
                new Claim(ClaimTypes.Email, userApp.Email),
                new Claim(ClaimTypes.Name, userApp.UserName),
                new Claim("FullName", $"{userApp.Name} {userApp.SurName}"),
                new Claim(ClaimTypes.Role, "")
            };

            DateTime expires = DateTime.UtcNow.AddMinutes(100000);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey));

            JwtSecurityToken jwtSecuritytoken = new(
                    issuer: jwtOptions.Value.Issuer,
                    audience: jwtOptions.Value.Audience,
                    claims : claims,
                    notBefore: DateTime.UtcNow,
                    expires: expires,
                    signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                );
            
            JwtSecurityTokenHandler tokenHandler = new();

            string token = tokenHandler.WriteToken(jwtSecuritytoken);
            string refreshToken = Guid.NewGuid().ToString();
            DateTime refreshTokenExpires = DateTime.UtcNow.AddDays(1);

            userApp.RefreshToken = refreshToken;
            userApp.RefreshTokenExpireDate = refreshTokenExpires;

            return new(token, refreshToken, refreshTokenExpires);
        }
    }
}
