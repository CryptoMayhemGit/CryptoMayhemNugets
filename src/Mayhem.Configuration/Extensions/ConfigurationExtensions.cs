using Mayhem.Configuration.Builders;
using Mayhem.Configuration.Interfaces;
using Mayhem.Configuration.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Mayhem.Configuration.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IMayhemConfigurationService AddMayhemConfigurationService(this IServiceCollection services, string azureConnectionString, string mayhemConfigurationType)
        {
            IMayhemConfigurationService mayhemConfiguration = BuildMayhemConfigurationObject(azureConnectionString, mayhemConfigurationType);

            services.AddSingleton(mayhemConfiguration);
            services.AddSingleton(mayhemConfiguration.MayhemConfiguration);

            return mayhemConfiguration;
        }

        private static IMayhemConfigurationService BuildMayhemConfigurationObject(string azureConnectionString, string mayhemConfigurationType)
        {
            return new MayhemConfigurationService(BuildMayhemServiceConfiguration(azureConnectionString, mayhemConfigurationType));
        }

        public static IMayhemConfiguration BuildMayhemServiceConfiguration(string azureConnectionString, string configurationType)
        {
            MayhemConfigurationBuilder mayhemCommonConfigurationBuilder = new(azureConnectionString, configurationType);
            return mayhemCommonConfigurationBuilder.GetSection<MayhemConfiguration>();
        }
    }
}
