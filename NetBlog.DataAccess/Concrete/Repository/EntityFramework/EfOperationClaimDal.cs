using NetBlog.Core.DataAccess.Concrete;
using NetBlog.Core.Entities.Concrete;
using NetBlog.DataAccess.Abstract;
using NetBlog.DataAccess.Concrete.Context;

namespace NetBlog.DataAccess.Concrete.Repository.EntityFramework
{
    public class EfOperationClaimDal : EntityRepositoryAsync<OperationClaim, NetBlogContext>, IOperationClaimDal
    {
        public EfOperationClaimDal(NetBlogContext context) : base(context)
        {
        }
    }
}
