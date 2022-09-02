namespace Mayhem.Cache
{
    public static class CacheKeys
    {
        private const string PlanetInstanceKey = nameof(PlanetInstanceKey);

        public static string GetPlanetInstanceKey(int instanceId)
        {
            return $"{PlanetInstanceKey}-{instanceId}";
        }
    }
}
