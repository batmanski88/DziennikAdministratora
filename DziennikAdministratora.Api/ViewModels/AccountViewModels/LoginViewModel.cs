using System;

namespace DziennikAdministratora.Api.ViewModels.AccountViewModels
{
    public class LoginViewModel
    {
        public Guid TokenId {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
    }
}