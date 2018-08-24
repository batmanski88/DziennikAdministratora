using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DziennikAdministratora.Api.ViewModels;
using DziennikAdministratora.Api.ViewModels.AccountViewModels;
using DziennikAdministratora.Api.ViewModels.RolesViewModels;
using DziennikAdministratora.Repository.IRepo;
using DziennikAdministratora.Repository.Model;

namespace DziennikAdministratora.Api.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        private readonly IEncrypter _encrypter;
        private readonly IJwtHandler _jwtHandler;
        private readonly IJwtRepo _jwtRepo;
        private readonly IRoleRepo _roleRepo;
        private readonly IUserInRoleRepo _userInRoleRepo;

        public AccountService(IUserRepo userRepo, IMapper mapper, IEncrypter encrypter, IJwtHandler jwtHandler, IJwtRepo jwtRepo, IRoleRepo roleRepo, IUserInRoleRepo userInRole)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _encrypter = encrypter;
            _jwtHandler = jwtHandler;
            _jwtRepo = jwtRepo;
            _roleRepo = roleRepo;
            _userInRoleRepo = userInRole;
        }

        public async Task<JwtModel> GetJwtAsync(string email)
        {
            var user = await _userRepo.GetUserByEmailAsync(email);
            var roles = new List<Role>();

            foreach(var UserInRole in user.UserInRoles)
            {
                roles.Add(UserInRole.Role);
            }

            var jwt = await _jwtRepo.GetJwtAsync(user.UserId);

            JwtModel jwtModel = new JwtModel()
            {
                Token = jwt.Token,
                ExpiryMinutes = jwt.ExpiryMinutes,
                UserRoles = _mapper.Map<List<RoleViewModel>>(roles)
            };

            return jwtModel;
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

            var jwt = await _jwtRepo.GetJwtAsync(user.UserId);

            if(jwt == null && user.Password == hash)
            {
                jwt = new Jwt(Guid.NewGuid(), user.UserId, tokenTemp.Token, tokenTemp.ExpiryMinutes);
                await _jwtRepo.SetJwtAsync(jwt);
            }
            else
            {
                jwt.SetToken(tokenTemp.Token);
                jwt.SetExpiryMinutes(tokenTemp.ExpiryMinutes);
                await _jwtRepo.UpdateJwtAsync(jwt);
            }
        }
    }
}