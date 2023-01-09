using MediatR;
using NetBlog.Core.Aspects.Caching;
using NetBlog.Core.Utilities.Results.Abstract;
using NetBlog.Core.Utilities.Results.Concrete;
using NetBlog.DataAccess.Repositories.CategoryRepository;

namespace NetBlog.Business.Repositories.CategoryRepository.Commands.RemoveCategory
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommandRequest, IResult>
    {
        private readonly ICategoryDal _categoryDal;

        public RemoveCategoryCommandHandler(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [RemoveCacheAspect("GetAllAsync")]
        public async Task<IResult> Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _categoryDal.DeleteAsync(request.Id);
            return new SuccessResult();
        }
    }
}
