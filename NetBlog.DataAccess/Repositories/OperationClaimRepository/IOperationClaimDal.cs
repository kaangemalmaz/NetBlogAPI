using NetBlog.Core.DataAccess.Abstract;
using NetBlog.Core.Entities.Concrete;
using NetBlog.DataAccess.Context.EntityFramework;

namespace NetBlog.DataAccess.Repositories.OperationClaimRepository
{
    public interface IOperationClaimDal : IEntityRepositoryAsync<OperationClaim, NetBlogContext>
    {
    }
}
