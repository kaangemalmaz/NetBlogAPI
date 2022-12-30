using NetBlog.Core.Entities.Abstract;

namespace NetBlog.Core.Entities.Concrete
{
    public class OperationClaim : BaseEntity, IEntity
    {
        public string Name { get; set; }
    }
}
