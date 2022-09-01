namespace Mayhem.Configuration.Interfaces
{
    /// <summary>
    /// Mayhem Configuration Service
    /// </summary>
    public interface IMayhemConfigurationService
    {
        /// <summary>
        /// Gets the mayhem configuration.
        /// </summary>
        /// <value>
        /// The mayhem configuration.
        /// </value>
        IMayhemConfiguration MayhemConfiguration { get; }
    }
}
