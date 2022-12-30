using Microsoft.AspNetCore.Http;

namespace NetBlog.Business.Abstract
{
    public interface IFileService
    {
        Task<string> FileSaveToServer(IFormFile formFile, string filePath);
    }
}
