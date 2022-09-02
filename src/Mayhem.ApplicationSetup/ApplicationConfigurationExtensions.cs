using AutoMapper;
using Azure.Storage.Blobs;
using HealthChecks.UI.Client;
using Mayhem.BlobStorage.Interfaces;
using Mayhem.BlobStorage.Services;
using Mayhem.Blockchain.Interfaces.Services;
using Mayhem.Cache.Interfaces;
using Mayhem.Cache.Services;
using Mayhem.Common.Services.PathFindingService.Implementations;
using Mayhem.Common.Services.PathFindingService.Interfaces;
using Mayhem.Configuration.Builders;
using Mayhem.Configuration.Classes;
using Mayhem.Configuration.Interfaces;
using Mayhem.Configuration.Services;
using Mayhem.HealthCheck;
using Mayhem.HttpClient.Implementation;
using Mayhem.HttpClient.Interfaces;
using Mayhem.Queue.Classes;
using Mayhem.Queue.Publisher.Notification;
using Mayhem.Settings;
using MediatR;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using Nethereum.Web3;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Mayhem.ApplicationSetup
{
    public static class ApplicationConfigurationExtensions
    {
        //public static void AddAutoMapperConfiguration(this IServiceCollection services)
        //{
        //    services.AddAutoMapper(typeof(NftStandardModelMapping), typeof(TableDtoMappings));
        //}

        //public static void AddMayhemContext(this IServiceCollection services, IMayhemConfigurationService mayhemConfigurationService)
        //{
        //    string connectionString = mayhemConfigurationService.MayhemConfiguration.ConnectionStringsConfigruation.MSSQLConnectionString;

        //    services
        //        .AddDbContext<MayhemDataContext>
        //        (
        //            options => options.UseSqlServer(connectionString)
        //        );

        //    services.AddScoped<IMayhemDataContext, MayhemDataContext>();
        //}

        //public static void AddServices(this IServiceCollection services, IMayhemConfigurationService mayhemConfiguration)
        //{
        //    services.AddMediator();
        //    services.AddRepositories();
        //    services.AddRestServices();
        //    services.AddPipelines();
        //    services.AddPublisher(mayhemConfiguration);
        //    services.AddBlockchain(mayhemConfiguration);
        //    services.AddApplicationInsightWithDefaultProcessor(mayhemConfiguration);
        //    services.AddAutoMapperConfiguration();
        //    services.AddMayhemContext(mayhemConfiguration);
        //    services.AddCustomHttpClient();
        //    services.AddCache(mayhemConfiguration);
        //    services.AddBlobStorage(mayhemConfiguration);
        //    services.AddCommonServices();
        //    services.AddSettings(mayhemConfiguration);
        //}

        public static void AddCustomHttpClient(this IServiceCollection services)
        {
            services.AddScoped<IHttpClientService, HttpClientService>();
        }

        public static void AddSettings(this IServiceCollection services, IMayhemConfigurationService mayhemConfigurationService)
        {
            IMayhemSettings mayhemSettings = new MayhemSettings();
            mayhemSettings.ReadSettings(mayhemConfigurationService.MayhemConfiguration.ConnectionStringsConfigruation.MSSQLConnectionString);
            services.AddSingleton(mayhemSettings);
        }

        public static void AddBlockchain(this IServiceCollection services, IMayhemConfigurationService mayhemConfiguration)
        {
            services.AddScoped<IWeb3>(x => new Web3(mayhemConfiguration.MayhemConfiguration.ServiceDiscoveryConfigruation.Web3ProviderEndpoint));
            services.Scan(scan => scan.FromAssemblyOf<IBlockchainService>().AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service"))).AsMatchingInterface());
        }

        //public static void AddServicesForUnitTests(this IServiceCollection services, IMayhemConfigurationService mayhemConfiguration)
        //{
        //    services.AddMayhemConfigurationService(Environment.GetEnvironmentVariable(EnviromentVariables.MayhemAzureAppConfigurationConnecitonString), Environment.GetEnvironmentVariable(EnviromentVariables.MayhemConfigurationType));
        //    services.AddMediator();
        //    services.AddBlockchain(mayhemConfiguration);
        //    services.AddPublisher(mayhemConfiguration);
        //    services.AddRepositories();
        //    services.AddRestServices();
        //    services.AddPipelines();
        //    //services.AddAutoMapperConfiguration();
        //}

        public static void AddCache(this IServiceCollection services, IMayhemConfigurationService mayhemConfiguration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = mayhemConfiguration.MayhemConfiguration.ConnectionStringsConfigruation.CacheConnectionString;
                options.InstanceName = mayhemConfiguration.MayhemConfiguration.CommonConfiguration.CacheName;
            });

            services.AddSingleton<ICacheService, CacheService>();
        }

        public static void AddBlobStorage(this IServiceCollection services, IMayhemConfigurationService mayhemConfiguration)
        {
            services.AddSingleton(x => new BlobServiceClient(mayhemConfiguration.MayhemConfiguration.ConnectionStringsConfigruation.AzureBlobStorageConnectionString));
            services.AddSingleton<IStorageService, StorageService>();
        }

        public static IMayhemConfigurationService AddMayhemConfigurationService(this IServiceCollection services, string azureConnectionString, string mayhemConfigurationType)
        {
            IMayhemConfigurationService mayhemConfiguration = BuildMayhemConfigurationObject(azureConnectionString, services, mayhemConfigurationType);

            services.AddSingleton(mayhemConfiguration);
            services.AddSingleton(mayhemConfiguration.MayhemConfiguration);

            return mayhemConfiguration;
        }

        public static IMayhemConfiguration BuildMayhemServiceConfiguration(string azureConnectionString, IServiceCollection services, string configurationType)
        {
            MayhemConfigurationBuilder mayhemCommonConfigurationBuilder = new(azureConnectionString, configurationType);
            return mayhemCommonConfigurationBuilder.GetSection<MayhemConfiguration>();
        }

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

        //public static void AddMediator(this IServiceCollection services)
        //{
        //    services.AddMediatR(typeof(LoginCommandRequest).Assembly);
        //}

        //public static void AddRepositories(this IServiceCollection services)
        //{
        //    services.Scan(scan => scan.FromAssemblyOf<IUserRepository>().AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository"))).AsMatchingInterface());
        //}

        //public static void AddRestServices(this IServiceCollection services)
        //{
        //    services.Scan(scan => scan.FromAssemblyOf<IAuthService>().AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service"))).AsMatchingInterface());
        //}

        //public static void AddPipelines(this IServiceCollection services)
        //{
        //    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        //    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        //}

        public static void AddPublisher(this IServiceCollection services, IMayhemConfigurationService mayhemConfigurationService)
        {
            NotificationQueuePublisher notificationQueuePublisher = new(new QueueConfiguration() { QueueName = QueueNames.NotificationQueue, ServiceBusConnectionString = mayhemConfigurationService.MayhemConfiguration.ConnectionStringsConfigruation.AzureQueueNotificationConnectionString });
            services.AddSingleton<INotificationQueuePublisher>(notificationQueuePublisher);
        }

        public static void AddApplicationInsightWithDefaultProcessor(this IServiceCollection services, IMayhemConfigurationService mayhemConfiguration)
        {
            ApplicationInsightsServiceOptions aiOptions = new()
            {
                InstrumentationKey = mayhemConfiguration.MayhemConfiguration.ConnectionStringsConfigruation.AppInsightInstrumentationKeyAPP,
            };

            services.AddApplicationInsightsTelemetry(aiOptions);
            services.AddApplicationInsightsTelemetryProcessor<DefaultTelemetryProcessor>();
        }

        //public static void AddJwtIdentity(this IServiceCollection services)
        //{
        //    services.AddIdentity<ApplicationUser, IdentityRole>()
        //        .AddEntityFrameworkStores<MayhemDataContext>()
        //        .AddDefaultTokenProviders();
        //}
        public static void AddCommonServices(this IServiceCollection services)
        {
            services.AddTransient<IPathFindingService, PathFindingService>();
        }

        public static void AddJwtAuthentication(this IServiceCollection services, IMayhemConfigurationService mmayhemConfiguration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = mmayhemConfiguration.MayhemConfiguration.ServiceSecretsConfigruation.JwtIssuer,
                    ValidAudience = mmayhemConfiguration.MayhemConfiguration.ServiceSecretsConfigruation.JwtAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(mmayhemConfiguration.MayhemConfiguration.ServiceSecretsConfigruation.JwtKey)),
                    ClockSkew = TimeSpan.Zero,
                };

                options.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }

        private static IMayhemConfigurationService BuildMayhemConfigurationObject(string azureConnectionString, IServiceCollection services, string mayhemConfigurationType)
        {
            return new MayhemConfigurationService(BuildMayhemServiceConfiguration(azureConnectionString, services, mayhemConfigurationType));
        }
    }
}
