using NetBlog.Core.Entities.Abstract;

namespace NetBlog.Entities.Dtos
{
    public class UserPasswordChangeDto : IDto
    {
        public int UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
