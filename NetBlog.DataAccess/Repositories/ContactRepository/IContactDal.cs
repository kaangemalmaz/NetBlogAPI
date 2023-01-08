using NetBlog.Core.DataAccess.Abstract;
using NetBlog.DataAccess.Context.EntityFramework;
using NetBlog.Entities.Concrete;

namespace NetBlog.DataAccess.Repositories.ContactRepository
{
    public interface IContactDal : IEntityRepositoryAsync<Contact, NetBlogContext>
    {
    }
}
