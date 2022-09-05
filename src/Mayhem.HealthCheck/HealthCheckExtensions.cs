using HealthChecks.UI.Client;
using Mayhem.Configuration.Interfaces;
using Mayhem.Queue.Classes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Mayhem.HealthCheck
{
    public static class HealthCheckExtensions
    {
        public static void AddCustomHealthChecks(this IServiceCollection services, IMayhemConfiguration mayhemConfiguration)
        {
            services.AddHealthChecksUI(settings =>
            {
                settings.SetEvaluationTimeInSeconds(300);
                settings.DisableDatabaseMigrations();
                settings.MaximumHistoryEntriesPerEndpoint(5);

                settings.AddHealthCheckEndpoint($"/api/{HealthCheckNames.Health}", $"{mayhemConfiguration.ServiceDiscoveryConfigruation.MayhemApiEndpoint}api/{HealthCheckNames.Health}");
                settings.AddHealthCheckEndpoint($"/api/{HealthCheckNames.Database}", $"{mayhemConfiguration.ServiceDiscoveryConfigruation.MayhemApiEndpoint}api/{HealthCheckNames.Database}");
                settings.AddHealthCheckEndpoint($"/api/{HealthCheckNames.AvatarAzureServiceBus}", $"{mayhemConfiguration.ServiceDiscoveryConfigruation.MayhemApiEndpoint}api/{HealthCheckNames.AvatarAzureServiceBus}");
                settings.AddHealthCheckEndpoint($"/api/{HealthCheckNames.LandAzureServiceBus}", $"{mayhemConfiguration.ServiceDiscoveryConfigruation.MayhemApiEndpoint}api/{HealthCheckNames.LandAzureServiceBus}");
                settings.AddHealthCheckEndpoint($"/api/{HealthCheckNames.ItemAzureServiceBus}", $"{mayhemConfiguration.ServiceDiscoveryConfigruation.MayhemApiEndpoint}api/{HealthCheckNames.ItemAzureServiceBus}");
                settings.AddHealthCheckEndpoint($"/api/{HealthCheckNames.NpcAzureServiceBus}", $"{mayhemConfiguration.ServiceDiscoveryConfigruation.MayhemApiEndpoint}api/{HealthCheckNames.NpcAzureServiceBus}");
                settings.AddHealthCheckEndpoint($"/api/{HealthCheckNames.DatabaseConnection}", $"{mayhemConfiguration.ServiceDiscoveryConfigruation.MayhemApiEndpoint}api/{HealthCheckNames.DatabaseConnection}");
                settings.AddHealthCheckEndpoint($"/api/{HealthCheckNames.Redis}", $"{mayhemConfiguration.ServiceDiscoveryConfigruation.MayhemApiEndpoint}api/{HealthCheckNames.Redis}");
                settings.AddHealthCheckEndpoint($"/api/{HealthCheckNames.AzureBlobStorage}", $"{mayhemConfiguration.ServiceDiscoveryConfigruation.MayhemApiEndpoint}api/{HealthCheckNames.AzureBlobStorage}");
            }).AddInMemoryStorage();

            services.AddHealthChecks()
                .AddCheck(HealthCheckNames.AlwaysHealthy, () => HealthCheckResult.Healthy(), tags: new[] { HealthCheckTags.All })
                .AddSqlServer(mayhemConfiguration.ConnectionStringsConfigruation.MSSQLConnectionString, name: HealthCheckNames.DatabaseConnection, tags: new[] { HealthCheckTags.All, HealthCheckTags.DatabaseConnection })
                .AddAzureServiceBusQueue(mayhemConfiguration.ConnectionStringsConfigruation.AzureQueueLandConnectionString, QueueNames.LandQueue, name: HealthCheckNames.LandAzureServiceBus, tags: new[] { HealthCheckTags.All, HealthCheckTags.LandAzureServiceBus })
                .AddAzureServiceBusQueue(mayhemConfiguration.ConnectionStringsConfigruation.AzureQueueItemConnectionString, QueueNames.ItemQueue, name: HealthCheckNames.ItemAzureServiceBus, tags: new[] { HealthCheckTags.All, HealthCheckTags.ItemAzureServiceBus })
                .AddAzureServiceBusQueue(mayhemConfiguration.ConnectionStringsConfigruation.AzureQueueNpcConnectionString, QueueNames.NpcQueue, name: HealthCheckNames.NpcAzureServiceBus, tags: new[] { HealthCheckTags.All, HealthCheckTags.NpcAzureServiceBus })
                .AddSqlServer(mayhemConfiguration.ConnectionStringsConfigruation.MSSQLConnectionString, HealthCheckQuery.DataBaseCRUDQuery, name: HealthCheckNames.Database, tags: new[] { HealthCheckTags.All, HealthCheckTags.Database })
                .AddRedis(mayhemConfiguration.ConnectionStringsConfigruation.CacheConnectionString, HealthCheckNames.Redis, tags: new[] { HealthCheckTags.All, HealthCheckTags.Redis })
                .AddAzureBlobStorage(mayhemConfiguration.ConnectionStringsConfigruation.AzureBlobStorageConnectionString, HealthCheckNames.AzureBlobStorage, tags: new[] { HealthCheckTags.All, HealthCheckTags.AzureStorageBlob });
        }

        public static void MapCustomHealthChecks(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapHealthChecksUI();

            endpoints.MapHealthChecks($"/api/{HealthCheckNames.Health}", new HealthCheckOptions()
            {
                Predicate = (check) => check.Tags.Contains(HealthCheckTags.All),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            endpoints.MapHealthChecks($"/api/{HealthCheckNames.Database}", new HealthCheckOptions()
            {
                Predicate = (check) => check.Tags.Contains(HealthCheckTags.Database),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            endpoints.MapHealthChecks($"/api/{HealthCheckNames.AvatarAzureServiceBus}", new HealthCheckOptions()
            {
                Predicate = (check) => check.Tags.Contains(HealthCheckTags.AvatarAzureServiceBus),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            endpoints.MapHealthChecks($"/api/{HealthCheckNames.LandAzureServiceBus}", new HealthCheckOptions()
            {
                Predicate = (check) => check.Tags.Contains(HealthCheckTags.LandAzureServiceBus),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            endpoints.MapHealthChecks($"/api/{HealthCheckNames.ItemAzureServiceBus}", new HealthCheckOptions()
            {
                Predicate = (check) => check.Tags.Contains(HealthCheckTags.ItemAzureServiceBus),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            endpoints.MapHealthChecks($"/api/{HealthCheckNames.NpcAzureServiceBus}", new HealthCheckOptions()
            {
                Predicate = (check) => check.Tags.Contains(HealthCheckTags.NpcAzureServiceBus),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            endpoints.MapHealthChecks($"/api/{HealthCheckNames.DatabaseConnection}", new HealthCheckOptions()
            {
                Predicate = (check) => check.Tags.Contains(HealthCheckTags.DatabaseConnection),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            endpoints.MapHealthChecks($"/api/{HealthCheckNames.Redis}", new HealthCheckOptions()
            {
                Predicate = (check) => check.Tags.Contains(HealthCheckTags.Redis),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            endpoints.MapHealthChecks($"/api/{HealthCheckNames.AzureBlobStorage}", new HealthCheckOptions()
            {
                Predicate = (check) => check.Tags.Contains(HealthCheckTags.AzureStorageBlob),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        }
    }
}
