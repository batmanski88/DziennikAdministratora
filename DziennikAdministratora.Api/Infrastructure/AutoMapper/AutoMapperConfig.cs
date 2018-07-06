using AutoMapper;
using DziennikAdministratora.Api.ViewModels;
using DziennikAdministratora.Api.ViewModels.AccountViewModels;
using DziennikAdministratora.Repository.Model;

namespace DziennikAdministratora.Api.Infrastructure.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>{
                cfg.CreateMap<User, LoginViewModel>();
                cfg.CreateMap<Jwt, JwtModel>();
                cfg.CreateMap<User, UserViewModel>();
            })
            .CreateMapper();
    }
}