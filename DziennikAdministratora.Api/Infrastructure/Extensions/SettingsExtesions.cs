using Microsoft.Extensions.Configuration;

namespace DziennikAdministratora.Api.Infrastructure.Extensions
{
    public static class SettingsExtesions
    {
        public static T GetSettings<T>(this IConfiguration configuration) where T : new()
        {
            var section = typeof(T).Name.Replace("Settings", string.Empty);

            var configurationValue = new T();
            configuration.GetSection(section).Bind(configurationValue);

            return configurationValue;
        }
    }
}