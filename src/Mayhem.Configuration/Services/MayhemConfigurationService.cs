using Mayhem.Configuration.Interfaces;

namespace Mayhem.Configuration.Services
{
    public class MayhemConfigurationService : IMayhemConfigurationService
    {
        private readonly IMayhemConfiguration _mayhemConfiguration;

        public MayhemConfigurationService(IMayhemConfiguration mayhemConfiguration)
        {
            _mayhemConfiguration = mayhemConfiguration;
        }

        public IMayhemConfiguration MayhemConfiguration => _mayhemConfiguration;
    }
}
