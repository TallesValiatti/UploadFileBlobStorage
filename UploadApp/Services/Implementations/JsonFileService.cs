using UploadApp.Services.Interfaces;

namespace UploadApp.Services.Implementations
{
    public class JsonFileService : IJsonFileService
    {
        public (FileStream, string) ReadJsonFile(string fullPath)
        {
           var fileInfo = new FileInfo(fullPath);

            if(!fileInfo.Exists)
                throw new Exception("Invalid fullPath");

            if(!string.Equals(fileInfo.Extension, ".json"))
                throw new Exception("Invalid extension");

            Console.WriteLine("Reading json file ...");
            var stream =  File.OpenRead(fullPath);
            Console.WriteLine("Done!");

            return (stream, fileInfo.Name);
        }      
    }
}