using NetBlog.Core.DataAccess.Concrete;
using NetBlog.DataAccess.Context.EntityFramework;
using NetBlog.Entities.Concrete;

namespace NetBlog.DataAccess.Repositories.PostRepository
{
    public class EfPostDal : EntityRepositoryAsync<Post, NetBlogContext>, IPostDal
    {
        public EfPostDal(NetBlogContext context) : base(context)
        {
        }
    }
}
