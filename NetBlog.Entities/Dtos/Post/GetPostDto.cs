using NetBlog.Core.Entities.Abstract;

namespace NetBlog.Entities.Dtos.Post
{
    // Defensive programming
    public class GetPostDto : BaseDto, IDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Thumbnail { get; set; } = string.Empty;
        public int CategoryId { get; set; }

    }
}
