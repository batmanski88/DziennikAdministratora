using System.Collections.Generic;
using System.Threading.Tasks;
using DziennikAdministratora.Repository.IRepo;
using DziennikAdministratora.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace DziennikAdministratora.Repository.Repo
{
    public class AppDbContext : DbContext, IAppDbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users {get; set;}
        public DbSet<Role> Roles {get; set;}
        public DbSet<Note> Notes {get; set;}
        public DbSet<Jwt> Jwts {get; set;}
        public DbSet<UserInRole> UserInRoles {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\v13.0;Initial Catalog=DziennikAdminaDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public async Task<int> SaveChangesAsync()
        {
           return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInRole>()
                .HasKey(x => new {x.UserId, x.RoleId});

            modelBuilder.Entity<UserInRole>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserInRoles)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UserInRole>()
                .HasOne(x => x.Role)
                .WithMany(x => x.UsersInRoles)
                .HasForeignKey(x => x.RoleId);
                
            base.OnModelCreating(modelBuilder);
        }

        public override DbSet<T> Set<T>()
        {
            return base.Set<T>();
        }
    }
}