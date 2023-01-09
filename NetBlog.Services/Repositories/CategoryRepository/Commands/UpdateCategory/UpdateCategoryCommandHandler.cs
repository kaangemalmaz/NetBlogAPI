using AutoMapper;
using MediatR;
using NetBlog.Business.Repositories.CategoryRepository.Rules;
using NetBlog.Business.Utilities.Constants;
using NetBlog.Core.Aspects.Caching;
using NetBlog.Core.Utilities.Business;
using NetBlog.Core.Utilities.Results.Abstract;
using NetBlog.Core.Utilities.Results.Concrete;
using NetBlog.DataAccess.Repositories.CategoryRepository;
using NetBlog.Entities.Concrete;

namespace NetBlog.Business.Repositories.CategoryRepository.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, IResult>
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public UpdateCategoryCommandHandler(ICategoryDal categoryDal, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
        }

        [RemoveCacheAspect("GetAllAsync")]
        public async Task<IResult> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            //kontroller
            IResult result = BusinessRules.Run(await _categoryBusinessRules.CategoryNameCannotBeDuplicated(request.Name));

            if (result != null) return new ErrorResult(result.Message);


            Category selectCategory = await _categoryDal.GetAsync(p=>p.Id == request.Id);
            if (selectCategory == null) return new ErrorResult(GeneralMessages.NotFoundData);

            await _categoryDal.UpdateAsync(_mapper.Map(request,selectCategory));
            return new SuccessResult();
        }
    }
}
