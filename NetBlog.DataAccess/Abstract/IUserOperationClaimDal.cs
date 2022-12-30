using NetBlog.Core.DataAccess.Abstract;
using NetBlog.Core.Entities.Concrete;
using NetBlog.DataAccess.Concrete.Context;

namespace NetBlog.DataAccess.Abstract
{
    public interface IUserOperationClaimDal : IEntityRepositoryAsync<UserOperationClaim, NetBlogContext>
    {
    }
}
