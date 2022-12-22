using NetBlog.Core.Entities.Abstract;

namespace NetBlog.Entities.Dtos.Comment
{
    // Defensive programming
    public class AddCommentDto : IDto
    {
        public string CreatedBy { get; set; } = String.Empty;

        public string Text { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int PostId { get; set; } = 0;
        public bool IsActive { get; set; } = false;
    }
}
