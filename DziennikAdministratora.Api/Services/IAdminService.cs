using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DziennikAdministratora.Api.ViewModels.AccountViewModels;

namespace DziennikAdministratora.Api.Services
{
    public interface IAdminService
    {
        Task RegisterUserAsync(RegisterViewModel model);
        Task<IEnumerable<UserViewModel>> GetUsersAsync();
        Task<UserViewModel> GetUserByIdAsync(Guid Id);
        Task DeleteUserAsync(Guid Id);
    }
}