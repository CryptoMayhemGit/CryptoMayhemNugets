using System.Threading.Tasks;

namespace Mayhem.Cache.Interfaces
{
    public interface ICacheService
    {
        Task<T> GetObjectAsync<T>(string key);
        Task<string> GetStringAsync(string key);
        Task RemoveAsync(string key);
        Task SetObjectAsync<T>(string key, T value);
        Task SetStringAsync(string key, string value);
    }
}
