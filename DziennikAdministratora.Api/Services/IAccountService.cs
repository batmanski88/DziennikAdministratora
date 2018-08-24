using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DziennikAdministratora.Api.ViewModels;
using DziennikAdministratora.Api.ViewModels.AccountViewModels;

namespace DziennikAdministratora.Api.Services
{
    public interface IAccountService
    {
        Task Login(LoginViewModel model);
        Task<JwtModel> GetJwtAsync(string email);
    }
}