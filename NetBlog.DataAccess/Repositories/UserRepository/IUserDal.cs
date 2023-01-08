using NetBlog.Core.DataAccess.Abstract;
using NetBlog.Core.Entities.Concrete;
using NetBlog.DataAccess.Context.EntityFramework;

namespace NetBlog.DataAccess.Repositories.UserRepository
{
    public interface IUserDal : IEntityRepositoryAsync<User, NetBlogContext>
    {
        Task<List<OperationClaim>> GetUserOperationClaims(int userId);
    }
}
