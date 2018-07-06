using System;
using System.Linq;
using System.Threading.Tasks;
using DziennikAdministratora.Repository.IRepo;
using DziennikAdministratora.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace DziennikAdministratora.Repository.Repo
{
    public class JwtRepo : IJwtRepo
    {
        private readonly IAppDbContext _context;

        public JwtRepo(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<Jwt> GetJwtAsync(Guid userId)
        {
            var jwts = await _context.Jwts.ToListAsync();
            return jwts.Where(x => x.UserId == userId).FirstOrDefault();
        }

        public async Task SetJwtAsync(Jwt jwt)
        {
            _context.Jwts.Add(jwt);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateJwtAsync(Jwt jwt)
        {
            _context.Jwts.Update(jwt);
            await _context.SaveChangesAsync();
        }
    }
}