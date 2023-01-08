using NetBlog.Core.DataAccess.Concrete;
using NetBlog.DataAccess.Context.EntityFramework;
using NetBlog.Entities.Concrete;

namespace NetBlog.DataAccess.Repositories.CategoryRepository
{
    public class EfCategoryDal : EntityRepositoryAsync<Category, NetBlogContext>, ICategoryDal
    {
        public EfCategoryDal(NetBlogContext context) : base(context)
        {
        }
    }
}
