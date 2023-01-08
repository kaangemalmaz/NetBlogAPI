using NetBlog.Core.DataAccess.Concrete;
using NetBlog.DataAccess.Context.EntityFramework;
using NetBlog.Entities.Concrete;

namespace NetBlog.DataAccess.Repositories.ContactRepository
{
    public class EfContactDal : EntityRepositoryAsync<Contact, NetBlogContext>, IContactDal
    {
        public EfContactDal(NetBlogContext context) : base(context)
        {
        }
    }
}
