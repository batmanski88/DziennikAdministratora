using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DziennikAdministratora.Api.ViewModels.RolesViewModels;
using DziennikAdministratora.Repository.Model;

namespace DziennikAdministratora.Api.Services
{
    public interface IRoleService
    {
        Task<RoleViewModel> GetRoleByIdAsync(Guid Id);
        Task AddRoleAsync(RoleViewModel model);
        Task<IEnumerable<RoleViewModel>> GetRolesAsync();
        Task RemoveRoleAsync(Guid Id);
        Task UpdateRolesAsync(RoleViewModel model);
    }
}