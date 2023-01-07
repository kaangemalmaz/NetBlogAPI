using NetBlog.Core.Entities.Abstract;

namespace NetBlog.Core.Entities.Concrete
{
    public class EmailParameter : BaseEntity, IEntity
    {
        public string Smtp { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public bool SSL { get; set; }
        public bool Html { get; set; }
    }
}
