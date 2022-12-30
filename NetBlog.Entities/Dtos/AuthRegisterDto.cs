using Microsoft.AspNetCore.Http;
using NetBlog.Core.Entities.Abstract;

namespace NetBlog.Entities.Dtos
{
    public class AuthRegisterDto : IDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string Password { get; set; }
    }
}
