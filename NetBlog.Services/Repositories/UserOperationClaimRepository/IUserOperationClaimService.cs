using NetBlog.Core.Entities.Concrete;
using NetBlog.Core.Utilities.Results.Abstract;

namespace NetBlog.Business.Repositories.UserOperationClaimRepository
{
    public interface IUserOperationClaimService
    {
        Task<IDataResult<IList<UserOperationClaim>>> GetAllAsync();
        Task<IDataResult<UserOperationClaim>> GetAsync(int id);
        Task<IDataResult<UserOperationClaim>> AddAsync(UserOperationClaim userOperationClaim);
        Task<IResult> UpdateAsync(UserOperationClaim userOperationClaim);
        Task<IResult> DeleteAsync(int id);
    }
}
