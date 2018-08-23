using System.Collections.Generic;
using DziennikAdministratora.Api.ViewModels.RolesViewModels;

namespace DziennikAdministratora.Api.ViewModels
{
    public class JwtModel
    {
        public string Token {get; set;}
        public long ExpiryMinutes {get; set;}
        public List<RoleViewModel> UserRoles {get; set;}
    }
}