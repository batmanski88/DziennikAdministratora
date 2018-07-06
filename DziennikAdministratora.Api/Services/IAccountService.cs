using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DziennikAdministratora.Api.ViewModels;
using DziennikAdministratora.Api.ViewModels.AccountViewModels;

namespace DziennikAdministratora.Api.Services
{
    public interface IAccountService
    {
        Task RegisterUserAsync(RegisterViewModel model);
        Task Login(LoginViewModel model);
        Task LogoutAsync();
        Task<JwtModel> GetJwtAsync(string email);
        Task<IEnumerable<UserViewModel>> GetUsersAsync();
        Task<UserViewModel> GetUserByIdAsync(Guid Id);
        Task DeleteUserAsync(Guid Id);
    }
}