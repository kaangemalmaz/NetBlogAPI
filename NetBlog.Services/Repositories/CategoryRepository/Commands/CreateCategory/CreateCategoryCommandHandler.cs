using AutoMapper;
using MediatR;
using NetBlog.Business.Repositories.CategoryRepository.Rules;
using NetBlog.Core.Aspects.Caching;
using NetBlog.Core.Utilities.Business;
using NetBlog.Core.Utilities.Results.Abstract;
using NetBlog.Core.Utilities.Results.Concrete;
using NetBlog.DataAccess.Repositories.CategoryRepository;
using NetBlog.Entities.Concrete;

namespace NetBlog.Business.Repositories.CategoryRepository.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, IResult>
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public CreateCategoryCommandHandler(ICategoryDal categoryDal, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
        }

        [RemoveCacheAspect("GetAllAsync")]
        public async Task<IResult> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            //kontroller
            IResult result = BusinessRules.Run(await _categoryBusinessRules.CategoryNameCannotBeDuplicated(request.Name));

            if (result != null) return new ErrorResult(result.Message);

            await _categoryDal.AddAsync(_mapper.Map<Category>(request));
            return new SuccessResult();
        }
    }
}
