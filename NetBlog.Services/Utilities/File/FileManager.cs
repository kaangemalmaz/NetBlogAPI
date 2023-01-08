using Microsoft.AspNetCore.Http;

namespace NetBlog.Business.Utilities.File
{
    public class FileManager : IFileService
    {
        public async Task<string> FileSaveToServer(IFormFile formFile, string filePath)
        {
            string fileName = formFile.FileName;
            var fileFormat = fileName.Substring(fileName.LastIndexOf(".")).ToLower();
            fileName = Guid.NewGuid().ToString() + fileFormat;

            string path = filePath + fileName;
            using (var stream = System.IO.File.Create(path))
            {
                formFile.CopyTo(stream);
            }

            return fileName;
        }
    }
}
