using Microsoft.EntityFrameworkCore;
using NetBlog.Core.DataAccess.Concrete;
using NetBlog.Core.Entities.Concrete;
using NetBlog.DataAccess.Abstract;
using NetBlog.DataAccess.Concrete.Context;

namespace NetBlog.DataAccess.Concrete.Repository.EntityFramework
{
    public class EfUserDal : EntityRepositoryAsync<User, NetBlogContext>, IUserDal
    {
        public EfUserDal(NetBlogContext context) : base(context)
        {
        }

        public async Task<List<OperationClaim>> GetUserOperationClaims(int userId)
        {
            var result = from userOperationClaim in _context.UserOperationClaims.Where(p => p.UserId == userId)
                         join operationClaim in _context.OperationClaims on userOperationClaim.OperationClaimId equals operationClaim.Id
                         select new OperationClaim
                         {
                             Id = operationClaim.Id,
                             Name = operationClaim.Name,
                         };

            return await result.OrderBy(o=>o.Name).ToListAsync();
        }
    }
}
