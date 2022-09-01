using Mayhem.Configuration.Interfaces;

namespace Mayhem.Configuration.Services
{
    public class MayhemConfiguration : IMayhemConfiguration
    {
        public ConnectionStringsConfigruation ConnectionStringsConfigruation { get; set; }
        public NotificationConfigruation NotificationConfigruation { get; set; }
        public ServiceDiscoveryConfigruation ServiceDiscoveryConfigruation { get; set; }
        public CommonConfiguration CommonConfiguration { get; set; }
        public ServiceSecretsConfigruation ServiceSecretsConfigruation { get; set; }
        public GeneratorConfiguration GeneratorConfiguration { get; set; }
    }
}
