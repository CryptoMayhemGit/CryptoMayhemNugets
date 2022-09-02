using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Mayhem.BlobStorage.Interfaces;
using Mayhem.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Mayhem.BlobStorage.Services
{
    public class StorageService : IStorageService
    {
        private readonly BlobServiceClient blobServiceClient;
        private readonly ILogger<StorageService> logger;
        private BlobHttpHeaders BlobHeader => new()
        {
            ContentType = "application/octet-stream",
        };

        public StorageService(ILogger<StorageService> logger, BlobServiceClient blobServiceClient)
        {
            this.logger = logger;
            this.blobServiceClient = blobServiceClient;
        }

        public string GetBlob(string name, string containerName)
        {
            logger.LogInformation(LoggerMessages.GettingBlobFor(name, containerName));
            BlobClient blobClient = GetBlobClient(name, containerName);
            return blobClient.Uri.AbsoluteUri;
        }
        public async Task<IEnumerable<string>> GetBlobsNameAsync(string containerName)
        {
            logger.LogInformation(LoggerMessages.GettingBlobsFor(containerName));
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            List<string> files = new();

            AsyncPageable<BlobItem> blobs = containerClient.GetBlobsAsync();
            await foreach (BlobItem item in blobs)
            {
                files.Add(item.Name);
            }

            return files;
        }
        public async Task<string> DownloadBlobAsync(string name, string containerName)
        {
            BlobClient blobClient = GetBlobClient(name, containerName);
            using MemoryStream stream = new();
            await blobClient.DownloadToAsync(stream);
            stream.Position = 0;
            using StreamReader streamReader = new(stream);
            return await streamReader.ReadToEndAsync();
        }
        public async Task<bool> UploadBlobAsync(string name, IFormFile file, string containerName)
        {
            logger.LogInformation(LoggerMessages.UploadingBlobFor(name, containerName));
            BlobClient blobClient = GetBlobClient(name, containerName);
            Response<BlobContentInfo> res = await blobClient.UploadAsync(file.OpenReadStream(), BlobHeader);
            return res != null;
        }
        public async Task DeleteBlobAsync(string name, string containerName)
        {
            logger.LogInformation(LoggerMessages.DeletingBlobFor(name, containerName));
            BlobClient blobClient = GetBlobClient(name, containerName);

            await blobClient.DeleteIfExistsAsync();
        }
        private BlobClient GetBlobClient(string name, string containerName)
        {
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            return containerClient.GetBlobClient(name);
        }
    }
}
