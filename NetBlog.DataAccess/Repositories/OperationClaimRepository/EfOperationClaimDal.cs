using NetBlog.Core.DataAccess.Concrete;
using NetBlog.Core.Entities.Concrete;
using NetBlog.DataAccess.Context.EntityFramework;

namespace NetBlog.DataAccess.Repositories.OperationClaimRepository
{
    public class EfOperationClaimDal : EntityRepositoryAsync<OperationClaim, NetBlogContext>, IOperationClaimDal
    {
        public EfOperationClaimDal(NetBlogContext context) : base(context)
        {
        }
    }
}
