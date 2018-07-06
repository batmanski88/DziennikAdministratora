using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using DziennikAdministratora.Api.Infrastructure.Configuration;
using DziennikAdministratora.Api.Infrastructure.Extensions;
using DziennikAdministratora.Api.ViewModels;
using DziennikAdministratora.Repository.IRepo;
using DziennikAdministratora.Repository.Model;
using Microsoft.IdentityModel.Tokens;

namespace DziennikAdministratora.Api.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings _jwtConfig;

        public JwtHandler(JwtSettings jwtConfig)
        {
            _jwtConfig = jwtConfig;
        }

        public JwtModel CreateToken(string userId, List<Role> roles)
        {
            var now = DateTime.UtcNow;
            var claims = new List<Claim>();

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, now.ToTimeStamp().ToString(), ClaimValueTypes.Integer64));

            foreach(var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item.Name.ToString()));
            }
            
            var expires = now.AddMinutes(_jwtConfig.ExpiryMinutes);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Key)), SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: _jwtConfig.Issuer,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtModel
            {
                Token = token,
                ExpiryMinutes = expires.ToTimeStamp()
            };
        }
    }
}