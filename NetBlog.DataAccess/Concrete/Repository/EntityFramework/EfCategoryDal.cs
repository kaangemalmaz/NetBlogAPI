using NetBlog.Core.DataAccess.Concrete;
using NetBlog.DataAccess.Abstract;
using NetBlog.DataAccess.Concrete.Context;
using NetBlog.Entities.Concrete;

namespace NetBlog.DataAccess.Concrete.Repository.EntityFramework
{
    public class EfCategoryDal : EntityRepositoryAsync<Category, NetBlogContext>, ICategoryDal
    {
        public EfCategoryDal(NetBlogContext context) : base(context)
        {
        }
    }
}
