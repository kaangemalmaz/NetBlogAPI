using NetBlog.Core.Entities.Abstract;

namespace NetBlog.Entities.Concrete
{
    public class Contact : BaseEntity, IEntity
    {
        public string Email { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
