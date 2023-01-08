using NetBlog.Core.DataAccess.Abstract;
using NetBlog.Core.Entities.Concrete;
using NetBlog.DataAccess.Context.EntityFramework;

namespace NetBlog.DataAccess.Repositories.EmailParameterRepository
{
    public interface IEmailParameterDal : IEntityRepositoryAsync<EmailParameter, NetBlogContext>
    {
    }
}
