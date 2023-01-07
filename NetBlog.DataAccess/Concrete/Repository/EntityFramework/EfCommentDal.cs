using NetBlog.Core.DataAccess.Concrete;
using NetBlog.DataAccess.Abstract;
using NetBlog.DataAccess.Concrete.Context;
using NetBlog.Entities.Concrete;

namespace NetBlog.DataAccess.Concrete.Repository.EntityFramework
{
    public class EfCommentDal : EntityRepositoryAsync<Comment, NetBlogContext>, ICommentDal
    {
        public EfCommentDal(NetBlogContext context) : base(context)
        {
        }
    }
}
