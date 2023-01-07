using NetBlog.Core.DataAccess.Concrete;
using NetBlog.Core.Entities.Concrete;
using NetBlog.DataAccess.Abstract;
using NetBlog.DataAccess.Concrete.Context;

namespace NetBlog.DataAccess.Concrete.Repository.EntityFramework
{
    public class EmailParameterDal : EntityRepositoryAsync<EmailParameter, NetBlogContext>, IEmailParameterDal
    {
        public EmailParameterDal(NetBlogContext context) : base(context)
        {
        }
    }
}
