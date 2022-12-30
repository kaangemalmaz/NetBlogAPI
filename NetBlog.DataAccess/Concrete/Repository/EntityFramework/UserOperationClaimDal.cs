using NetBlog.Core.DataAccess.Concrete;
using NetBlog.Core.Entities.Concrete;
using NetBlog.DataAccess.Abstract;
using NetBlog.DataAccess.Concrete.Context;

namespace NetBlog.DataAccess.Concrete.Repository.EntityFramework
{
    public class UserOperationClaimDal : EntityRepositoryAsync<UserOperationClaim, NetBlogContext>, IUserOperationClaimDal
    {
        public UserOperationClaimDal(NetBlogContext context) : base(context)
        {
        }
    }
}
