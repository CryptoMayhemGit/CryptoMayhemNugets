using FluentAssertions;
using Mayhem.Configuration.Classes;
using Mayhem.Configuration.Extensions;
using Mayhem.Configuration.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;

namespace Mayhem.Nuget.Tests
{
    public class ConfigurationTests
    {
        [Test]
        public void Test()
        {
            IServiceCollection services = new ServiceCollection();
                services.AddMayhemConfigurationService(Environment.GetEnvironmentVariable(
                    EnviromentVariables.MayhemAzureAppConfigurationConnecitonString), 
                    Environment.GetEnvironmentVariable(EnviromentVariables.MayhemConfigurationType));

            ServiceProvider? provider = services.BuildServiceProvider();
            IMayhemConfiguration? service = provider.GetService<IMayhemConfiguration>();
            service?.CommonConfiguration.Should().NotBeNull();
            service?.ConnectionStringsConfigruation.Should().NotBeNull();
            service?.GeneratorConfiguration.Should().NotBeNull();
            service?.NotificationConfigruation.Should().NotBeNull();
            service?.ServiceSecretsConfigruation.Should().NotBeNull();
            service?.ServiceDiscoveryConfigruation.Should().NotBeNull();
        }
    }
}