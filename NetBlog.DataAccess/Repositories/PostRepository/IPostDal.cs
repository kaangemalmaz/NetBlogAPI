using NetBlog.Core.DataAccess.Abstract;
using NetBlog.DataAccess.Context.EntityFramework;
using NetBlog.Entities.Concrete;

namespace NetBlog.DataAccess.Repositories.PostRepository
{
    public interface IPostDal : IEntityRepositoryAsync<Post, NetBlogContext>
    {
    }
}
