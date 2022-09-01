namespace Mayhem.Configuration.Builders
{
    public class MayhemConfigurationBuilder : MayhemConfigurationBuilderBase
    {
        public MayhemConfigurationBuilder(string azureConnectionString, string configurationType)
            : base($"{configurationType}.MayhemConfiguration.json", azureConnectionString)
        {
        }
    }
}
