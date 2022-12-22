using NetBlog.Core.Entities.Abstract;

namespace NetBlog.Entities.Concrete
{
    public class Category : BaseEntity, IEntity
    {
        public string Name { get; set; } = String.Empty;
        public List<Post>? Posts { get; set; }
    }
}
