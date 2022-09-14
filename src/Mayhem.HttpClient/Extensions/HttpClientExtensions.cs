using Mayhem.HttpClient.Implementation;
using Mayhem.HttpClient.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Mayhem.HttpClient.Extensions
{
    public static class HttpClientExtensions
    {
        public static void AddCustomHttpClient(this IServiceCollection services)
        {
            services.AddScoped<IHttpClientService, HttpClientService>();
        }
    }
}
