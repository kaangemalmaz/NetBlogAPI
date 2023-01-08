using NetBlog.Core.DataAccess.Abstract;
using NetBlog.DataAccess.Context.EntityFramework;
using NetBlog.Entities.Concrete;

namespace NetBlog.DataAccess.Repositories.CommentRepository
{
    public interface ICommentDal : IEntityRepositoryAsync<Comment, NetBlogContext>
    {

    }
}
