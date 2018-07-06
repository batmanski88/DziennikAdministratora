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

        public async Task DeleteUserAsync(Guid Id)
        {
            await _userRepo.RemoveUserAsync(Id);
        }

        public async Task<JwtModel> GetJwtAsync(string email)
        {
            var user = await _userRepo.GetUserByEmailAsync(email);
            var jwt = await _jwtRepo.GetJwtAsync(user.UserId);

            return _mapper.Map<JwtModel>(jwt);
        }

        public async Task<UserViewModel> GetUserByIdAsync(Guid Id)
        {
            var user = await _userRepo.GetUserByIdAsync(Id);

            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<IEnumerable<UserViewModel>> GetUsersAsync()
        {
            var users = await _userRepo.GetUsersAsync();
            var uservmList = new List<UserViewModel>();

            foreach(var item in users)
            {   
                var userInRoles = item.UserInRoles;
                var rolevmList = new List<RoleViewModel>();

                foreach(var userInRole in item.UserInRoles)
                {
                    var role = await _roleRepo.GetRoleByIdAsync(userInRole.RoleId);
                    rolevmList.Add(_mapper.Map<RoleViewModel>(role));
                }

                var uservm = new UserViewModel()
                {   
                    UserId = item.UserId,
                    Email = item.Email,
                    Roles = rolevmList,
                    CreatedAt = item.CreateAt,
                    UpdatetAt = item.UpdateAt
                };

                uservmList.Add(uservm);
            }

            return uservmList;
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
            var jwt = new Jwt(Guid.NewGuid(), user.UserId, tokenTemp.Token, tokenTemp.ExpiryMinutes);

            if(user.Password == hash)
            {
                await _jwtRepo.SetJwtAsync(jwt);
            }
        }

        public Task LogoutAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task RegisterUserAsync(RegisterViewModel model)
        {
            var user = await _userRepo.GetUserByEmailAsync(model.Email);

            if(user != null)
            {
                throw new Exception("Użytkownik już istnieje w bazie");
            }

            var salt = _encrypter.GetSalt(model.Password);
            var hash = _encrypter.GetHash(model.Password, salt);

            user = new User(Guid.NewGuid(), model.Email, hash, salt);
            await _userRepo.AddUserAsync(user);
            
            user.UserInRoles.Add(new UserInRole(user.UserId, model.Role.RoleId));
            await _userInRoleRepo.SaveUserInRoles(user.UserInRoles);
        }
    }
}