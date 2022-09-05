using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mayhem.Settings
{
    public static class SettingsExtensions
    {
        public static void AddSettings(this IServiceCollection services, string msSqlConnectionString)
        {
            IMayhemSettings mayhemSettings = new MayhemSettings();
            mayhemSettings.ReadSettings(msSqlConnectionString);
            services.AddSingleton(mayhemSettings);
        }
    }
}
