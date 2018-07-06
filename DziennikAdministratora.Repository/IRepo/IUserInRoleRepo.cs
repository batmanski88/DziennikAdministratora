using System.Collections.Generic;
using System.Threading.Tasks;
using DziennikAdministratora.Repository.Model;

namespace DziennikAdministratora.Repository.IRepo
{
    public interface IUserInRoleRepo
    {
         Task SaveUserInRoles(IEnumerable<UserInRole> userInRoles);
         Task DeleteUserInRoles(IEnumerable<UserInRole> userInRoles);
    }
}