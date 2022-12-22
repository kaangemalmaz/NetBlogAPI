using NetBlog.Core.DataAccess.Concrete;
using NetBlog.DataAccess.Abstract;
using NetBlog.DataAccess.Concrete.Context;
using NetBlog.Entities.Concrete;

namespace NetBlog.DataAccess.Concrete.Repository.EntityFramework
{
    public class CategoryDal : EntityRepositoryAsync<Category, NetBlogContext>, ICategoryDal
    {
        public CategoryDal(NetBlogContext context) : base(context)
        {
        }
    }
}
