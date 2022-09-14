using Microsoft.Extensions.DependencyInjection;

namespace Mayhem.Settings
{
    public static class SettingsExtensions
    {
        public static void AddSettings(this IServiceCollection services, string msSqlConnectionString)
        {
            IMayhemSettings mayhemSettings = new MayhemSettings();
            mayhemSettings.ReadSettings(msSqlConnectionString);
            services.AddSingleton(mayhemSettings);
        }
    }
}
