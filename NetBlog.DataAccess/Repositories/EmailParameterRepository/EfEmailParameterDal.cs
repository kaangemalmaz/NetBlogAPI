using NetBlog.Core.DataAccess.Concrete;
using NetBlog.Core.Entities.Concrete;
using NetBlog.DataAccess.Context.EntityFramework;

namespace NetBlog.DataAccess.Repositories.EmailParameterRepository
{
    public class EfEmailParameterDal : EntityRepositoryAsync<EmailParameter, NetBlogContext>, IEmailParameterDal
    {
        public EfEmailParameterDal(NetBlogContext context) : base(context)
        {
        }
    }
}
