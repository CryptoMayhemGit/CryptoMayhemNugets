using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mayhem.BlobStorage.Interfaces
{
    public interface IStorageService
    {
        string GetBlob(string name, string containerName);
        Task<IEnumerable<string>> GetBlobsNameAsync(string containerName);
        Task<bool> UploadBlobAsync(string name, IFormFile file, string containerName);
        Task DeleteBlobAsync(string fileName, string containerName);
        Task<string> DownloadBlobAsync(string name, string containerName);
    }
}
