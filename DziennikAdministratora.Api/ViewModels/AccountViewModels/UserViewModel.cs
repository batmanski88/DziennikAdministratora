using System;
using System.Collections.Generic;
using DziennikAdministratora.Api.ViewModels.RolesViewModels;

namespace DziennikAdministratora.Api.ViewModels.AccountViewModels
{
    public class UserViewModel
    {
        public Guid UserId {get; set;}
        public string Email {get; set;}
        public string UserName {get; set;}
        public List<RoleViewModel> Roles {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatetAt {get; set;}
    }
}