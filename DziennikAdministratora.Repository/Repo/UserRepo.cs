using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikAdministratora.Repository.IRepo;
using DziennikAdministratora.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace DziennikAdministratora.Repository.Repo
{
    public class UserRepo : IUserRepo
    {
        public readonly IAppDbContext _context;

        public UserRepo(IAppDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {   
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var users = await _context.Users.Include("UserInRoles").ToListAsync();
            return users.Where(x => x.Email == email).FirstOrDefault();
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            var users = await _context.Users.Include("UserInRoles").ToListAsync();
            return users.Where(x => x.UserId == userId).FirstOrDefault();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {   
            var users = await _context.Users.Include("UserInRoles").ToListAsync();
            return users;
        }

        public async Task RemoveUserAsync(Guid userId)
        {
            var users = await _context.Users.ToListAsync();
            _context.Users.Remove(users.Where(x => x.UserId == userId).FirstOrDefault());
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}