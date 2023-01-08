using NetBlog.Core.DataAccess.Abstract;
using NetBlog.DataAccess.Context.EntityFramework;
using NetBlog.Entities.Concrete;

namespace NetBlog.DataAccess.Repositories.CategoryRepository
{
    public interface ICategoryDal : IEntityRepositoryAsync<Category, NetBlogContext>
    {

    }
}
