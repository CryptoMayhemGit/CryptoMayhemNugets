using Mayhem.Cache.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mayhem.Cache.Mocks
{
    public class CacheServiceMock : ICacheService
    {
        private readonly Dictionary<string, object> cache = new();

        public async Task<T> GetObjectAsync<T>(string key)
        {
            bool result = cache.TryGetValue(key, out object value);
            return result == true ? await Task.FromResult((T)value) : default;
        }

        public async Task<string> GetStringAsync(string key)
        {
            bool result = cache.TryGetValue(key, out object value);
            return result == true ? await Task.FromResult(value.ToString()) : default;
        }

        public async Task RemoveAsync(string key)
        {
            await Task.FromResult(cache.Remove(key));
        }

        public async Task SetObjectAsync<T>(string key, T value)
        {
            cache.Add(key, value);
            await Task.FromResult(true);
        }

        public async Task SetStringAsync(string key, string value)
        {
            cache.Add(key, value);
            await Task.FromResult(true);
        }
    }
}
