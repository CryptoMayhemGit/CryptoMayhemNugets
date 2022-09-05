using Azure.Storage.Blobs;
using Mayhem.BlobStorage.Interfaces;
using Mayhem.BlobStorage.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Mayhem.BlobStorage.Extensions
{
    public static class BlobStorageExtensions
    {
        public static void AddBlobStorage(this IServiceCollection services, string azureBlobStorageConnectionString)
        {
            services.AddSingleton(x => new BlobServiceClient(azureBlobStorageConnectionString));
            services.AddSingleton<IStorageService, StorageService>();
        }
    }
}
