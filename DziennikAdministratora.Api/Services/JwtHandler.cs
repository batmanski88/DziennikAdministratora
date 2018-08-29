using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using DziennikAdministratora.Api.Infrastructure.Configuration;
using DziennikAdministratora.Api.Infrastructure.Extensions;
using DziennikAdministratora.Api.ViewModels;
using DziennikAdministratora.Api.ViewModels.RolesViewModels;
using DziennikAdministratora.Repository.IRepo;
using DziennikAdministratora.Repository.Model;
using Microsoft.IdentityModel.Tokens;

namespace DziennikAdministratora.Api.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings _jwtConfig;
        private readonly IMapper _mapper;

        public JwtHandler(JwtSettings jwtConfig, IMapper mapper)
        {
            _jwtConfig = jwtConfig;
            _mapper = mapper;
        }

        public JwtModel CreateToken(string userId, List<Role> roles)
        {
            var now = DateTime.UtcNow;
            var claims = new List<Claim>();

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, now.ToTimeStamp().ToString(), ClaimValueTypes.Integer64));

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token");

            claimsIdentity.AddClaims(roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));
            
            var expires = now.AddMinutes(_jwtConfig.ExpiryMinutes);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Key)), SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: _jwtConfig.Issuer,
                audience: _jwtConfig.Issuer,
                claims: claimsIdentity.Claims,
                expires: expires,
                signingCredentials: signingCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtModel
            {
                Token = token,
                ExpiryMinutes = expires.ToTimeStamp(),
                UserRoles = _mapper.Map<List<RoleViewModel>>(roles) 
            };
        }
    }
}