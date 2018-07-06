using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DziennikAdministratora.Repository.Model;

namespace DziennikAdministratora.Repository.IRepo
{
    public interface IRoleRepo
    {
         Task<Role> GetRoleByIdAsync(Guid roleId);
         Task<IEnumerable<Role>> GetRolesAsync();
         Task AddRoleAsync(Role role);
         Task UpdateRoleAsync(Role role);
         Task RemoveRoleAsync(Guid roleId);
    }
}