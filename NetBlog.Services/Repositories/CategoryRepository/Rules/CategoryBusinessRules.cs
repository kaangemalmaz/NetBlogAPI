using NetBlog.Business.Utilities.Constants;
using NetBlog.Core.Utilities.Results.Abstract;
using NetBlog.Core.Utilities.Results.Concrete;
using NetBlog.DataAccess.Repositories.CategoryRepository;

namespace NetBlog.Business.Repositories.CategoryRepository.Rules
{
    public class CategoryBusinessRules
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryBusinessRules(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<IResult> CategoryNameCannotBeDuplicated(string name)
        {
            var result = await _categoryDal.GetAsync(p=>p.Name == name);
            if (result != null) return new ErrorResult(GeneralMessages.NameMustBeUnique);
            return new SuccessResult();
        }

        public async Task<IResult> CategoryNotFound(int id)
        {
            var result = await _categoryDal.GetAsync(p => p.Id == id);
            if (result == null) return new ErrorResult(GeneralMessages.NotFoundData);
            return new SuccessResult();
        }
    }
}
