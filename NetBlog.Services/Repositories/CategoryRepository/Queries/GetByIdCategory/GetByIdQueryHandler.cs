using AutoMapper;
using MediatR;
using NetBlog.DataAccess.Repositories.CategoryRepository;
using NetBlog.Entities.Dtos.Category;

namespace NetBlog.Business.Repositories.CategoryRepository.Queries.GetByIdCategory
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQueryRequest, GetCategoryDto>
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public async Task<GetCategoryDto> Handle(GetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryDal.GetAsync(p => p.Id == request.Id);
            return _mapper.Map<GetCategoryDto>(category);
        }
    }
}
