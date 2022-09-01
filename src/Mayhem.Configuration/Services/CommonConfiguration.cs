namespace Mayhem.Configuration.Services
{
    public class CommonConfiguration
    {
        public int HttpClientServicePostTimeout { get; set; }
        public int TokenLifetimeInMinutes { get; set; }
        public int NonceLifetimeInMinutes { get; set; }
        public bool ApiAuthorizationEnabled { get; set; }
        public bool BlockchainAuthorizationEnabled { get; set; }
        public int TransferIntervalInSeconds { get; set; }
        public int ResendNotificationInMinutes { get; set; }
        public string GetLogsTopic { get; set; }
        public int MaxBlocksToProcessed { get; set; }

        public string NftNpcDescription { get; set; }
        public string NftItemDescription { get; set; }
        public string NftLandDescription { get; set; }

        public string NftNpcSmartContractAddress { get; set; }
        public string NftItemSmartContractAddress { get; set; }
        public string NftLandSmartContractAddress { get; set; }

        public string CacheName { get; set; }
        public int ResendNotificationTimeInMinutes { get; set; }
        public int TryResendNotificationTimeInMinutes { get; set; }
        public int ResendNotificationOlderThenInMinutes { get; set; }
        public int MaxNotificationAttempts { get; set; }

        public int NpcMoveSpeedInSeconds { get; set; }
        public int DiscovertyMissionSpeedInSeconds { get; set; }
        public int ExploreMissionSpeedInSeconds { get; set; }
        public int PlanetSize { get; set; }
        public int RunPathWorkerInSeconds { get; set; }

        public int RunDiscoveryMissionWorkerTimeInSeconds { get; set; }
        public int RunExploreMissionWorkerTimeInSeconds { get; set; }
    }
}
