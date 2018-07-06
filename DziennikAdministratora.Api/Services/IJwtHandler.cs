using System.Collections.Generic;
using DziennikAdministratora.Api.ViewModels;
using DziennikAdministratora.Repository.Model;

namespace DziennikAdministratora.Api.Services
{
    public interface IJwtHandler
    {
        JwtModel CreateToken(string userId, List<Role> roles);
    }
}