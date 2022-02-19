using UploadApp.Services.Interfaces;

namespace UploadApp.Services.Implementations
{
    public class FileManagementService : IFileManagementService
    {
        private readonly IJsonFileService _jsonFileService;
        private readonly IRemoteStorageService _remoteStorageService;
        public FileManagementService()
        {
            _remoteStorageService = new RemoteStorageService();
            _jsonFileService = new JsonFileService();
        }
        public async Task UploadLocalFileToRemoteStorageAsync(string fullPath)
        {
            var jsonFile = _jsonFileService.ReadJsonFile(fullPath);
            var stream = jsonFile.Item1;
            var fileName = jsonFile.Item2;

            if(await _remoteStorageService.ExistsFileAsync(fileName))
                throw new Exception("File already exists on remote storage");

            await _remoteStorageService.UploadFileAsync(fileName, stream);
        }
    }
}