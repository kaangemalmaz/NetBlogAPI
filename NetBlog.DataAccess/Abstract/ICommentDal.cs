using NetBlog.Core.DataAccess.Abstract;
using NetBlog.DataAccess.Concrete.Context;
using NetBlog.Entities.Concrete;

namespace NetBlog.DataAccess.Abstract
{
    public interface ICommentDal : IEntityRepositoryAsync<Comment, NetBlogContext>
    {

    }
}
