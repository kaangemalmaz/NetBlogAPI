using NetBlog.Core.Entities.Abstract;

namespace NetBlog.Entities.Concrete
{
    public class Post : BaseEntity, IEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Thumbnail { get; set; } = string.Empty;
        //public int ViewCount { get; set; } = 0;
        //public int CommentCount { get; set; } = 0;
        //public string? UpdatedByName { get; set; }
        //public DateTime UpdatedDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
