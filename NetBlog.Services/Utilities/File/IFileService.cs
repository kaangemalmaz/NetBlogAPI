using Microsoft.AspNetCore.Http;

namespace NetBlog.Business.Utilities.File
{
    public interface IFileService
    {
        Task<string> FileSaveToServer(IFormFile formFile, string filePath);
    }
}
