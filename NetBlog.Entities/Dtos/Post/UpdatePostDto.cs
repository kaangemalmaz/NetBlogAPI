using NetBlog.Core.Entities.Abstract;

namespace NetBlog.Entities.Dtos.Post
{
    // Defensive programming
    public class UpdatePostDto : IDto
    {
        public string LastModifiedBy { get; set; } = String.Empty;
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Thumbnail { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}
