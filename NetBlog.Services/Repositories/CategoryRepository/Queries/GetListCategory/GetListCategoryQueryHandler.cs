using AutoMapper;
using MediatR;
using NetBlog.Core.Aspects.Caching;
using NetBlog.Core.Aspects.Performance;
using NetBlog.Core.Aspects.Secured;
using NetBlog.DataAccess.Repositories.CategoryRepository;
using NetBlog.Entities.Dtos.Category;

namespace NetBlog.Business.Repositories.CategoryRepository.Queries.GetListCategory
{
    public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQueryRequest, List<GetCategoryDto>>
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;

        public GetListCategoryQueryHandler(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        [SecuredAspect("GetAll")]
        [PerformanceAspect]
        [CacheAspect]
        public async Task<List<GetCategoryDto>> Handle(GetListCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryDal.GetAllAsync();
            List<GetCategoryDto> getCategoryDtos = _mapper.Map<List<GetCategoryDto>>(categories); 
            return getCategoryDtos;
        }
    }
}
