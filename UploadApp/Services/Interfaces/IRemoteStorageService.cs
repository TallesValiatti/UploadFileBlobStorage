namespace UploadApp.Services.Interfaces
{
    public interface IRemoteStorageService
    {
        Task UploadFileAsync(string fileName, Stream stream);
        Task<bool> ExistsFileAsync(string fileName);
    }
}