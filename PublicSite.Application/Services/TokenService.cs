using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PublicSite.Application.Dtos.Authentication;
using PublicSite.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PublicSite.Application.Services
{
    public class TokenService(IConfiguration _config) : ITokenService
    {
        public string GenerateAccessToken(TokenClaimDto claim)
        {
            if (claim.Email is null)
            {
                throw new Exception("The Email must not be null");
            }

            var claims = new Claim[]
            {
                new Claim("email", claim.Email),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            double tokenExpiredHour = double.TryParse(_config["Jwt:TokenExpired:Hours"], out var time) ? time : 1;
            double tokenExpiredMinute = double.TryParse(_config["Jwt:TokenExpired:Minutes"], out time) ? time : 0;

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(tokenExpiredHour).AddMinutes(tokenExpiredMinute),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken(string code)
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(randomNumber);
            return code + Convert.ToBase64String(randomNumber);
        }
    }
}
