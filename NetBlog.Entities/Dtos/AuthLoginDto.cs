using NetBlog.Core.Entities.Abstract;

namespace NetBlog.Entities.Dtos
{
    public class AuthLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
