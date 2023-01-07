using NetBlog.Core.DataAccess.Concrete;
using NetBlog.DataAccess.Abstract;
using NetBlog.DataAccess.Concrete.Context;
using NetBlog.Entities.Concrete;

namespace NetBlog.DataAccess.Concrete.Repository.EntityFramework
{
    public class EfPostDal : EntityRepositoryAsync<Post, NetBlogContext>, IPostDal
    {
        public EfPostDal(NetBlogContext context) : base(context)
        {
        }
    }
}
