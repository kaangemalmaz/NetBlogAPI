using NetBlog.Core.Entities.Abstract;

namespace NetBlog.Core.Entities.Concrete
{
    public class User : BaseEntity, IEntity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
