using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DziennikAdministratora.Api.Infrastructure.Extensions;
using DziennikAdministratora.Api.ViewModels;
using DziennikAdministratora.Api.ViewModels.AccountViewModels;
using DziennikAdministratora.Api.ViewModels.RolesViewModels;
using DziennikAdministratora.Repository.IRepo;
using DziennikAdministratora.Repository.Model;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace DziennikAdministratora.Api.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        private readonly IEncrypter _encrypter;
        private readonly IJwtHandler _jwtHandler;
        private readonly IRoleRepo _roleRepo;
        private readonly IUserInRoleRepo _userInRoleRepo;
        private readonly IMemoryCache _cache;

        public AccountService(IUserRepo userRepo, IMapper mapper, IEncrypter encrypter, IJwtHandler jwtHandler, IRoleRepo roleRepo, IUserInRoleRepo userInRole, IMemoryCache cache)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _encrypter = encrypter;
            _jwtHandler = jwtHandler;
            _roleRepo = roleRepo;
            _userInRoleRepo = userInRole;
            _cache = cache;
        }

        public async Task Login(LoginViewModel model)
        {
            var user = await _userRepo.GetUserByEmailAsync(model.Email);
            if(user == null)
            {
                throw new Exception("Użytkownik nie istnieje");
            }

            var userInRoles = user.UserInRoles;
            var roles = new List<Role>();

            foreach(var item in userInRoles)
            {
                var role = await _roleRepo.GetRoleByIdAsync(item.RoleId);
                roles.Add(role);
            }
            
            var hash = _encrypter.GetHash(model.Password, user.Salt);
            var tokenTemp = _jwtHandler.CreateToken(user.UserId.ToString(), roles);
            
            if(user.Password == hash)
            {
                _cache.SetJwt(model.TokenId, tokenTemp);
            }
        }
    }
}