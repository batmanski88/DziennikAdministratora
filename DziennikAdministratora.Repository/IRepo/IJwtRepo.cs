using System;
using System.Threading.Tasks;
using DziennikAdministratora.Repository.Model;

namespace DziennikAdministratora.Repository.IRepo
{
    public interface IJwtRepo
    {
        Task SetJwtAsync(Jwt jwt);
        Task<Jwt> GetJwtAsync(Guid userId);
        Task UpdateJwtAsync(Jwt jwt);
    }
}