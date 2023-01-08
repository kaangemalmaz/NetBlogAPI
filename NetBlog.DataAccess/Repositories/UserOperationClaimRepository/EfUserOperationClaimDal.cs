using NetBlog.Core.DataAccess.Concrete;
using NetBlog.Core.Entities.Concrete;
using NetBlog.DataAccess.Context.EntityFramework;

namespace NetBlog.DataAccess.Repositories.UserOperationClaimRepository
{
    public class EfUserOperationClaimDal : EntityRepositoryAsync<UserOperationClaim, NetBlogContext>, IUserOperationClaimDal
    {
        public EfUserOperationClaimDal(NetBlogContext context) : base(context)
        {
        }
    }
}
