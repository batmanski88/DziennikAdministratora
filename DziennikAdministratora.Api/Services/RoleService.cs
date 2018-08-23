using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DziennikAdministratora.Api.ViewModels.RolesViewModels;
using DziennikAdministratora.Repository.IRepo;
using DziennikAdministratora.Repository.Model;

namespace DziennikAdministratora.Api.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepo _roleRepo;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepo roleRepo, IMapper mapper)
        {
            _roleRepo = roleRepo;
            _mapper = mapper;
        }

        public async Task AddRoleAsync(RoleViewModel model)
        {
            var role = new Role(Guid.NewGuid(), model.Name);
            await _roleRepo.AddRoleAsync(role);
        }

        public async Task<IEnumerable<RoleViewModel>> GetRolesAsync()
        {
            var roles = await _roleRepo.GetRolesAsync();

            return _mapper.Map<IEnumerable<RoleViewModel>>(roles);
        }

        public async Task<RoleViewModel> GetRoleByIdAsync(Guid roleId)
        {
            var user = await _roleRepo.GetRoleByIdAsync(roleId);
            return _mapper.Map<RoleViewModel>(user);
        }

        public async Task RemoveRoleAsync(Guid roleId)
        {
            await _roleRepo.RemoveRoleAsync(roleId);
        }

        public async Task UpdateRolesAsync(RoleViewModel model)
        {
            var role = await _roleRepo.GetRoleByIdAsync(model.RoleId);
            role.SetName(model.Name);
            await _roleRepo.UpdateRoleAsync(role);
        }
    }
}