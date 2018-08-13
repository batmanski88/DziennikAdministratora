using System.Threading.Tasks;
using DziennikAdministratora.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace DziennikAdministratora.Repository.IRepo
{
    public interface IAppDbContext
    {   
        DbSet<T> Set<T>() where T : class; 
        Task<int> SaveChangesAsync();
        DbSet<User> Users {get; set;}
        DbSet<Role> Roles {get; set;}
        DbSet<Note> Notes {get; set;}
        DbSet<Jwt> Jwts {get; set;}
        DbSet<UserInRole> UserInRoles {get; set;}
    }
}