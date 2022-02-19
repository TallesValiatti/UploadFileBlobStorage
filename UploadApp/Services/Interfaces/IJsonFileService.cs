namespace UploadApp.Services.Interfaces
{
    public interface IJsonFileService
    {
        (FileStream, string) ReadJsonFile(string fullPath);
    }
}