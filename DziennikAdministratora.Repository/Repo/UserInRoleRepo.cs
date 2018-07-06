using System.Collections.Generic;
using System.Threading.Tasks;
using DziennikAdministratora.Repository.IRepo;
using DziennikAdministratora.Repository.Model;

namespace DziennikAdministratora.Repository.Repo
{
    public class UserInRoleRepo : IUserInRoleRepo
    {
        private readonly IAppDbContext _context;

        public UserInRoleRepo(IAppDbContext context)
        {
            _context = context;
        }

        public Task DeleteUserInRoles(IEnumerable<UserInRole> userInRoles)
        {
            throw new System.NotImplementedException();
        }

        public async Task SaveUserInRoles(IEnumerable<UserInRole> userInRoles)
        {
            foreach(var item in userInRoles)
            {
                _context.UserInRoles.Add(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}