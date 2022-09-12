using Mayhem.Common.Services.PathFindingService.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Mayhem.Common.Services.Extensions
{
    public static class CommonServicesExtensions
    {
        public static void AddCommonServices(this IServiceCollection services)
        {
            services.AddTransient<IPathFindingService, PathFindingService.Implementations.PathFindingService>();
        }
    }
}
