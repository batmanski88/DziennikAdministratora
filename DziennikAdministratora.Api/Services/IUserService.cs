using System;
using System.Threading.Tasks;

namespace DziennikAdministratora.Api.Services
{
    public interface IUserService
    {
        Task UpdatePassword(string password); 
    }
}