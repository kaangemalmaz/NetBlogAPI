using AutoMapper;
using NetBlog.Business.Abstract;
using NetBlog.Business.Utilities;
using NetBlog.Core.Entities.Concrete;
using NetBlog.Core.Utilities.Results.Abstract;
using NetBlog.Core.Utilities.Results.Concrete;
using NetBlog.DataAccess.Abstract;
using NetBlog.Entities.Dtos.OperaionClaim;

namespace NetBlog.Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;
        private readonly IMapper _mapper;

        public OperationClaimManager(IOperationClaimDal operationClaimDal, IMapper mapper)
        {
            _operationClaimDal = operationClaimDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<OperationClaim>> AddAsync(AddOperationClaim addOperationClaim)
        {
            try
            {
                OperationClaim addedOperationClaim = await _operationClaimDal.AddAsync(_mapper.Map<OperationClaim>(addOperationClaim));
                return new SuccessDataResult<OperationClaim>(addedOperationClaim);
            }
            catch (Exception)
            {
                return new ErrorDataResult<OperationClaim>(GeneralMessages.GeneralError);
            }
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            try
            {
                if (id <= 0) return new ErrorResult(GeneralMessages.IdMustBeGreaterZero);

                await _operationClaimDal.DeleteAsync(id);
                return new SuccessResult();
            }
            catch (Exception)
            {
                return new ErrorDataResult<OperationClaim>(GeneralMessages.GeneralError);
            }
        }

        public async Task<IDataResult<IList<OperationClaim>>> GetAllAsync()
        {
            try
            {
                IList<OperationClaim> operationClaims =  await _operationClaimDal.GetAllAsync();
                if(operationClaims.Count == 0) return new ErrorDataResult<IList<OperationClaim>>(GeneralMessages.NotFoundData);

                return new SuccessDataResult<IList<OperationClaim>>();
            }
            catch (Exception)
            {
                return new ErrorDataResult<IList<OperationClaim>>(GeneralMessages.GeneralError);
            }
        }

        public async Task<IDataResult<OperationClaim>> GetAsync(int id)
        {
            try
            {
                OperationClaim operationClaim =  await _operationClaimDal.GetAsync(o => o.Id == id);
                if (operationClaim == null) return new ErrorDataResult<OperationClaim>(GeneralMessages.NotFoundData);

                return new SuccessDataResult<OperationClaim>(operationClaim);
            }
            catch (Exception)
            {
                return new ErrorDataResult<OperationClaim>(GeneralMessages.GeneralError);
            }
        }

        public async Task<IResult> UpdateAsync(UpdateOperationClaim updateOperationClaim)
        {
            try
            {
                if (updateOperationClaim.Id == null || updateOperationClaim.Id == 0) return new ErrorResult(GeneralMessages.IdMustBeGreaterZero);

                OperationClaim operationClaim = await _operationClaimDal.GetAsync(o => o.Id == updateOperationClaim.Id);
                if (operationClaim == null) return new ErrorResult(GeneralMessages.NotFoundData);

                await _operationClaimDal.UpdateAsync(_mapper.Map<UpdateOperationClaim, OperationClaim>(updateOperationClaim,operationClaim));
                return new SuccessResult();
            }
            catch (Exception)
            {
                return new ErrorResult(GeneralMessages.GeneralError);
            }
        }
    }
}
