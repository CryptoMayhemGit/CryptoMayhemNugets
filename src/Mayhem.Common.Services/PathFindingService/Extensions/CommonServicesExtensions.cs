using Mayhem.Common.Services.PathFindingService.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Mayhem.Common.Services.PathFindingService.Extensions
{
    public static class CommonServicesExtensions
    {
        public static void AddCommonServices(this IServiceCollection services)
        {
            services.AddTransient<IPathFindingService, Implementations.PathFindingService>();
        }
    }
}
