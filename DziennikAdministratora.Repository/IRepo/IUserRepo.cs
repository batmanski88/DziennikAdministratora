using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DziennikAdministratora.Repository.Model;

namespace DziennikAdministratora.Repository.IRepo
{
    public interface IUserRepo
    {
         Task<User> GetUserByIdAsync(Guid userId);
         Task<User> GetUserByEmailAsync(string email);
         Task<IEnumerable<User>> GetUsersAsync();
         Task AddUserAsync(User user);
         Task RemoveUserAsync(Guid userId);
         Task UpdateUserAsync(User user);
    }
}