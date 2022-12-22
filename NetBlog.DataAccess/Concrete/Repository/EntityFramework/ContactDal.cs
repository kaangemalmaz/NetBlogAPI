using NetBlog.Core.DataAccess.Concrete;
using NetBlog.DataAccess.Abstract;
using NetBlog.DataAccess.Concrete.Context;
using NetBlog.Entities.Concrete;

namespace NetBlog.DataAccess.Concrete.Repository.EntityFramework
{
    public class ContactDal : EntityRepositoryAsync<Contact, NetBlogContext>, IContactDal
    {
        public ContactDal(NetBlogContext context) : base(context)
        {
        }
    }
}
