using Mayhem.Cache.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace Mayhem.Cache.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache distributedCache;
        public CacheService(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }

        public async Task SetStringAsync(string key, string value)
        {
            await distributedCache.SetStringAsync(key, value);
        }

        public async Task SetObjectAsync<T>(string key, T value)
        {
            await distributedCache.SetAsync(key, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value)));
        }

        public async Task<string> GetStringAsync(string key)
        {
            return await distributedCache.GetStringAsync(key);
        }

        public async Task<T> GetObjectAsync<T>(string key)
        {
            byte[] value = await distributedCache.GetAsync(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(value));
        }

        public async Task RemoveAsync(string key)
        {
            await distributedCache.RemoveAsync(key);
        }
    }
}
