using NetBlog.Core.Entities.Abstract;

namespace NetBlog.Entities.Concrete
{
    public class Comment : BaseEntity, IEntity
    {
        public string Text { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int? ParentCommentId { get; set; } //ana için
        //public DateTime UpdatedTime { get; set; }
        public Comment ParentComment { get; set; } //parent ana için yani
        public List<Comment> SubComment { get; set; } //alt commentleri dönecek ona ait
        public int PostId { get; set; } = 0;
        public Post Post { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
