using Mayhem.HttpClient.Implementation;
using Mayhem.HttpClient.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
