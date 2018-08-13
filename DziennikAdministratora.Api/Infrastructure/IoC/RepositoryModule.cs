using Autofac;
using DziennikAdministratora.Repository;
using DziennikAdministratora.Repository.IRepo;
using DziennikAdministratora.Repository.Repo;
using Microsoft.EntityFrameworkCore;

namespace DziennikAdministratora.Api.Infrastructure.IoC
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppDbContext>()
                .As<IAppDbContext>()
                .InstancePerLifetimeScope();
                
            builder.RegisterType<UserRepo>()
                .As<IUserRepo>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<RoleRepo>()
                .As<IRoleRepo>()
                .InstancePerLifetimeScope();

            builder.RegisterType<NoteRepo>()
                .As<INoteRepo>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<JwtRepo>()
                .As<IJwtRepo>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserInRoleRepo>()
                .As<IUserInRoleRepo>()
                .InstancePerLifetimeScope();

        }
    }
}