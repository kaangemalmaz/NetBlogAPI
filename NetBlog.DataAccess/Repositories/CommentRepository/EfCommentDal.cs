using NetBlog.Core.DataAccess.Concrete;
using NetBlog.DataAccess.Context.EntityFramework;
using NetBlog.Entities.Concrete;

namespace NetBlog.DataAccess.Repositories.CommentRepository
{
    public class EfCommentDal : EntityRepositoryAsync<Comment, NetBlogContext>, ICommentDal
    {
        public EfCommentDal(NetBlogContext context) : base(context)
        {
        }
    }
}
