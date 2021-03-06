using Azure.Storage.Blobs;
using UploadApp.Services.Interfaces;

namespace UploadApp.Services.Implementations
{
    public class RemoteStorageService : IRemoteStorageService
    {
        private const string _connectionString = "<My-ConnectionString>";
        private const string _containerName = "mycontainer";
        private readonly BlobContainerClient _containerClient;
        private readonly BlobServiceClient _blobServiceClient;
        public RemoteStorageService()
        {
            _blobServiceClient = new BlobServiceClient(_connectionString);
            _containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
        }

        public async Task<bool> ExistsFileAsync(string fileName)
        {
             Console.WriteLine("Verifying is the file exists on remote storage ...");
             var blob = _containerClient.GetBlobClient(fileName);
             var exists = await blob.ExistsAsync();
             return exists;
        }

        public async Task UploadFileAsync(string fileName, Stream stream)
        {
            if(string.IsNullOrEmpty(fileName))
                throw new Exception("Invalid fileName");

            Console.WriteLine("Uploading the file to the remote storage ...");
            
            BlobClient blobClient = _containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(stream);

            Console.WriteLine("Done!");
        }
    }
}
