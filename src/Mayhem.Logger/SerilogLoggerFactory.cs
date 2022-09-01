using Microsoft.Extensions.Configuration;
using Serilog;
using System.IO;

namespace Mayhem.Logger
{
    public class SerilogLoggerFactory
    {
        public static ILogger CreateSerilogLogger()
        {
            IConfiguration configuration = GetConfigurationForSerilog();
            LoggerConfiguration loggerConfiguration = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration);

            return loggerConfiguration.CreateLogger();
        }

        private static IConfiguration GetConfigurationForSerilog()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            return builder.Build();
        }
    }
}
