using Mayhem.Configuration.Services;

namespace Mayhem.Configuration.Interfaces
{
    /// <summary>
    /// Mayhem Configuration
    /// </summary>
    public interface IMayhemConfiguration
    {
        /// <summary>
        /// Gets or sets the connection strings configruation.
        /// </summary>
        /// <value>
        /// The connection strings configruation.
        /// </value>
        ConnectionStringsConfigruation ConnectionStringsConfigruation { get; set; }
        /// <summary>
        /// Gets or sets the notification configruation.
        /// </summary>
        /// <value>
        /// The notification configruation.
        /// </value>
        NotificationConfigruation NotificationConfigruation { get; set; }
        /// <summary>
        /// Gets or sets the service discovery configruation.
        /// </summary>
        /// <value>
        /// The service discovery configruation.
        /// </value>
        ServiceDiscoveryConfigruation ServiceDiscoveryConfigruation { get; set; }
        /// <summary>
        /// Gets or sets the common configuration.
        /// </summary>
        /// <value>
        /// The common configuration.
        /// </value>
        CommonConfiguration CommonConfiguration { get; set; }
        /// <summary>
        /// Gets or sets the service secrets configruation.
        /// </summary>
        /// <value>
        /// The service secrets configruation.
        /// </value>
        ServiceSecretsConfigruation ServiceSecretsConfigruation { get; set; }
        /// <summary>
        /// Gets or sets the generator configuration.
        /// </summary>
        /// <value>
        /// The generator configuration.
        /// </value>
        GeneratorConfiguration GeneratorConfiguration { get; set; }
    }
}
