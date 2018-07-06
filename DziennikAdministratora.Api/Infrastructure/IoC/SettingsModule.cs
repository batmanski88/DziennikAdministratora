using Autofac;
using DziennikAdministratora.Api.Infrastructure.Configuration;
using DziennikAdministratora.Api.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;

namespace DziennikAdministratora.Api.Infrastructure.IoC
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>()).SingleInstance();
        }
    }
}