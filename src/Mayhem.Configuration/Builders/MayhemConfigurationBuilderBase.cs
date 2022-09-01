using Mayhem.Messages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mayhem.Configuration.Builders
{
    public class MayhemConfigurationBuilderBase
    {
        private IConfigurationRoot configuration { get; }
        private readonly bool azureProviderRequired;

        protected MayhemConfigurationBuilderBase(string jsonFileName, string azureConnectionString)
        {
            azureProviderRequired = !string.IsNullOrEmpty(azureConnectionString);

            string baseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs");

            ConfigurationBuilder configBuilder = new();

            configBuilder.SetBasePath(baseDirectory);

            if (File.Exists(Path.Combine(baseDirectory, jsonFileName)))
            {
                configBuilder.AddJsonFile(jsonFileName, optional: true, reloadOnChange: true);
            }

            configBuilder.AddEnvironmentVariables();

            if (azureProviderRequired)
            {
                configBuilder.AddAzureAppConfiguration(options =>
                    options
                        .Connect(azureConnectionString)
                        .Select(KeyFilter.Any, LabelFilter.Null)
                );
            }

            configuration = configBuilder.Build();
        }

        public T GetSection<T>()
            where T : class, new()
        {
            T section = new();
            string sectionName = typeof(T).Name;

            IConfigurationSection conf = configuration.GetSection(sectionName);

            if (azureProviderRequired)
            {
                IConfigurationProvider azureProvider;

                try
                {
                    azureProvider = configuration.Providers.First(p => p.ToString() == "AzureAppConfigurationProvider");
                }
                catch
                {
                    throw ExceptionMessages.AzureConfigurationRequiredException;
                }

                IEnumerable<string> sectionKeys = azureProvider.GetChildKeys(new List<string>(), sectionName);

                if (!sectionKeys.Any())
                {
                    throw ExceptionMessages.AzureConfigurationHasNoKeysException(sectionName);
                }
            }

            if (configuration.GetChildren().SingleOrDefault(c => c.Key == sectionName) == null)
            {
                throw ExceptionMessages.MissingSectionConfigurationFileException(typeof(T).Name);
            }

            conf.Bind(section);
            return section;
        }
    }
}
