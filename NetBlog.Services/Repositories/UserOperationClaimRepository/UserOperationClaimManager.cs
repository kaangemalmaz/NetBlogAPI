using NetBlog.Business.Utilities.Constants;
using NetBlog.Core.Entities.Concrete;
using NetBlog.Core.Utilities.Results.Abstract;
using NetBlog.Core.Utilities.Results.Concrete;
using NetBlog.DataAccess.Repositories.UserOperationClaimRepository;

namespace NetBlog.Business.Repositories.UserOperationClaimRepository
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public async Task<IDataResult<UserOperationClaim>> AddAsync(UserOperationClaim userOperationClaim)
        {
            try
            {
                await _userOperationClaimDal.AddAsync(userOperationClaim);
                return new SuccessDataResult<UserOperationClaim>();
            }
            catch (Exception)
            {
                return new ErrorDataResult<UserOperationClaim>(GeneralMessages.GeneralError);
            }
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            try
            {
                if (id <= 0) return new ErrorResult(GeneralMessages.IdMustBeGreaterZero);

                await _userOperationClaimDal.DeleteAsync(id);
                return new SuccessResult();
            }
            catch (Exception)
            {
                return new ErrorDataResult<UserOperationClaim>(GeneralMessages.GeneralError);
            }
        }

        public async Task<IDataResult<IList<UserOperationClaim>>> GetAllAsync()
        {
            try
            {
                var userOperationClaim = await _userOperationClaimDal.GetAllAsync();
                return new SuccessDataResult<IList<UserOperationClaim>>(userOperationClaim);
            }
            catch (Exception)
            {
                return new ErrorDataResult<IList<UserOperationClaim>>(GeneralMessages.GeneralError);
            }
        }

        public async Task<IDataResult<UserOperationClaim>> GetAsync(int id)
        {
            try
            {
                await _userOperationClaimDal.GetAsync(o => o.Id == id);
                return new SuccessDataResult<UserOperationClaim>();
            }
            catch (Exception)
            {
                return new ErrorDataResult<UserOperationClaim>(GeneralMessages.GeneralError);
            }
        }

        public async Task<IResult> UpdateAsync(UserOperationClaim userOperationClaim)
        {
            try
            {
                await _userOperationClaimDal.UpdateAsync(userOperationClaim);
                return new SuccessResult();
            }
            catch (Exception)
            {
                return new ErrorResult(GeneralMessages.GeneralError);
            }
        }
    }
}
