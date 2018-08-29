using Autofac;
using DziennikAdministratora.Api.Services;

namespace DziennikAdministratora.Api.Infrastructure.IoC
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {       
            builder.RegisterType<JwtHandler>()
                .As<IJwtHandler>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Encrypter>()
                .As<IEncrypter>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AccountService>()
                .As<IAccountService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RoleService>()
                .As<IRoleService>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<AdminService>()
                .As<IAdminService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<NoteService>()
                .As<INoteService>()
                .InstancePerLifetimeScope();
        }
    }
}