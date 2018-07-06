using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikAdministratora.Repository.IRepo;
using DziennikAdministratora.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace DziennikAdministratora.Repository.Repo
{
    public class RoleRepo : IRoleRepo
    {
        private readonly IAppDbContext _context;

        public RoleRepo(IAppDbContext context) => _context = context;

        public async Task AddRoleAsync(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
        }

        public async Task<Role> GetRoleByIdAsync(Guid roleId)
        {
            var roles = await _context.Roles.ToListAsync();
            return roles.Where(x => x.RoleId == roleId).FirstOrDefault();
        }

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task RemoveRoleAsync(Guid roleId)
        {
            var roles = await _context.Roles.ToListAsync();
            _context.Roles.Remove(roles.Where(x =>x.RoleId == roleId).FirstOrDefault());
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoleAsync(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }
    }
}