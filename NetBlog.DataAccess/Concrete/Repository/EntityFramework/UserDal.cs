using NetBlog.Core.DataAccess.Concrete;
using NetBlog.Core.Entities.Concrete;
using NetBlog.DataAccess.Abstract;
using NetBlog.DataAccess.Concrete.Context;

namespace NetBlog.DataAccess.Concrete.Repository.EntityFramework
{
    public class UserDal : EntityRepositoryAsync<User, NetBlogContext>, IUserDal
    {
        public UserDal(NetBlogContext context) : base(context)
        {
        }
    }
}
