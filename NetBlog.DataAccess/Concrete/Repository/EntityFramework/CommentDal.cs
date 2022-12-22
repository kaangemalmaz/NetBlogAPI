using NetBlog.Core.DataAccess.Concrete;
using NetBlog.DataAccess.Abstract;
using NetBlog.DataAccess.Concrete.Context;
using NetBlog.Entities.Concrete;

namespace NetBlog.DataAccess.Concrete.Repository.EntityFramework
{
    public class CommentDal : EntityRepositoryAsync<Comment, NetBlogContext>, ICommentDal
    {
        public CommentDal(NetBlogContext context) : base(context)
        {
        }
    }
}
