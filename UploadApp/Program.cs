using UploadApp.Services.Implementations;
using UploadApp.Services.Interfaces;

Console.WriteLine("Specify the the name of file to be uploaded:");
var fullPath = Console.ReadLine();

if(!string.IsNullOrWhiteSpace(fullPath))
{
    IFileManagementService fileManagementService = new FileManagementService();
    try
    {
       await fileManagementService.UploadLocalFileToRemoteStorageAsync(fullPath.Trim());    
    }
    catch (System.Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
else
    Console.WriteLine("Invalid fullPath");
