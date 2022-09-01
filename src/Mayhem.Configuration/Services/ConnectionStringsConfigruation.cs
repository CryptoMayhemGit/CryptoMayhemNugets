namespace Mayhem.Configuration.Services
{
    public class ConnectionStringsConfigruation
    {
        public string MSSQLConnectionString { get; set; }
        public string AzureQueueNpcConnectionString { get; set; }
        public string AzureQueueItemConnectionString { get; set; }
        public string AzureQueueLandConnectionString { get; set; }
        public string AppInsightInstrumentationKeyAPP { get; set; }
        public string AzureQueueNotificationConnectionString { get; set; }
        public string CacheConnectionString { get; set; }
        public string AzureBlobStorageConnectionString { get; set; }
    }
}
