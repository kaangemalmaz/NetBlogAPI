using NetBlog.Core.Entities.Concrete;
using NetBlog.Core.Utilities.Results.Abstract;
using NetBlog.Entities.Dtos.OperaionClaim;

namespace NetBlog.Business.Abstract
{
    public interface IOperationClaimService
    {
        Task<IDataResult<IList<OperationClaim>>> GetAllAsync();
        Task<IDataResult<OperationClaim>> GetAsync(int id);
        Task<IDataResult<OperationClaim>> AddAsync(AddOperationClaim addOperationClaim);
        Task<IResult> UpdateAsync(UpdateOperationClaim updateOperationClaim);
        Task<IResult> DeleteAsync(int id);
    }
}
