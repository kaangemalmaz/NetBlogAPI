using NetBlog.Core.Entities.Abstract;

namespace NetBlog.Core.Entities.Concrete
{
    public class UserOperationClaim : BaseEntity, IEntity
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
