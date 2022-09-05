using Mayhem.Cache.Interfaces;
using Mayhem.Cache.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Mayhem.Cache.Extensions
{
    public static class CacheExtensions
    {
        public static void AddCache(this IServiceCollection services, string cacheConnectionString, string cacheName)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = cacheConnectionString;
                options.InstanceName = cacheName;
            });

            services.AddSingleton<ICacheService, CacheService>();
        }
    }
}
