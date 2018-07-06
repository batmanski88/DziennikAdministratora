using System.Collections.Generic;
using DziennikAdministratora.Api.ViewModels.RolesViewModels;

namespace DziennikAdministratora.Api.ViewModels.AccountViewModels
{
    public class RegisterViewModel
    {
        public string Email {get; set;}
        public string Password {get; set;}
        public string RePassword {get; set;}
        public RoleViewModel Role {get; set;}
    }
}