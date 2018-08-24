using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DziennikAdministratora.Api.ViewModels.AccountViewModels;
using DziennikAdministratora.Api.ViewModels.RolesViewModels;
using DziennikAdministratora.Repository.IRepo;
using DziennikAdministratora.Repository.Model;

namespace DziennikAdministratora.Api.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        private readonly IEncrypter _encrypter;
        private readonly IRoleRepo _roleRepo;
        private readonly IUserInRoleRepo _userInRoleRepo;

        public AdminService(IUserRepo userRepo, IMapper mapper, IEncrypter encrypter, IRoleRepo roleRepo, IUserInRoleRepo userInRole)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _encrypter = encrypter;
            _roleRepo = roleRepo;
            _userInRoleRepo = userInRole;
        }

        public async Task DeleteUserAsync(Guid Id)
        {
            await _userRepo.RemoveUserAsync(Id);
        }

        public async Task<UserViewModel> GetUserByIdAsync(Guid Id)
        {
            var user = await _userRepo.GetUserByIdAsync(Id);
            var roles = await _roleRepo.GetRolesAsync();
            var rolesByUserId = roles.Select(x => x.UsersInRoles.Select(y => y.UserId == Id));
            
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
                    UserName = item.UserName,
                    Roles = rolevmList,
                    CreatedAt = item.CreateAt,
                    UpdatetAt = item.UpdateAt
                };

                uservmList.Add(uservm);
            }

            return uservmList;
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