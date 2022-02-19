namespace UploadApp.Services.Interfaces
{
    public interface IFileManagementService
    {
         Task UploadLocalFileToRemoteStorageAsync(string fullPath);
    }
}