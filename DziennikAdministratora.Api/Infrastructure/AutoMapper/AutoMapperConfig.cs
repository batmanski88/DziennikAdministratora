using System.Linq;
using AutoMapper;
using DziennikAdministratora.Api.ViewModels;
using DziennikAdministratora.Api.ViewModels.AccountViewModels;
using DziennikAdministratora.Api.ViewModels.RolesViewModels;
using DziennikAdministratora.Repository.Model;

namespace DziennikAdministratora.Api.Infrastructure.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>{
                cfg.CreateMap<User, LoginViewModel>();
                cfg.CreateMap<Jwt, JwtModel>();
                cfg.CreateMap<Role, RoleViewModel>();
                cfg.CreateMap<UserInRole, RoleViewModel>()
                   .ForMember(x => x.Name, opt => opt.MapFrom(cp => cp.Role.Name))
                   .ForMember(x => x.RoleId, opt => opt.MapFrom(cp => cp.RoleId));
                cfg.CreateMap<User, UserViewModel>()
                   .ForMember(x => x.Roles, opt => opt.MapFrom(c => c.UserInRoles));
            })
            .CreateMapper();
    }
}