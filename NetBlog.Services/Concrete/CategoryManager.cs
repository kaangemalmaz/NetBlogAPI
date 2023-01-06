using AutoMapper;
using NetBlog.Business.Abstract;
using NetBlog.Business.Constants;
using NetBlog.Business.Utilities;
using NetBlog.Core.Aspects.Caching;
using NetBlog.Core.Utilities.Business;
using NetBlog.Core.Utilities.Results.Abstract;
using NetBlog.Core.Utilities.Results.Concrete;
using NetBlog.DataAccess.Abstract;
using NetBlog.Entities.Concrete;
using NetBlog.Entities.Dtos.Category;

namespace NetBlog.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        // loose coupling
        // referans tutucu
        // service collection değişirse burası otomatik değişiyor.
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        [RemoveCacheAspect("GetAllAsync")]
        public async Task<IDataResult<GetCategoryDto>> AddAsync(AddCategoryDto addCategoryDto)
        {
            try
            {
                //kontrol
                var result = BusinessRules.Run(await NameMustBeUnique(addCategoryDto.Name));
                if (result != null) return new ErrorDataResult<GetCategoryDto>(result.Message);

                //process
                Category addedCategory = await _categoryDal.AddAsync(_mapper.Map<Category>(addCategoryDto));
                return new SuccessDataResult<GetCategoryDto>(_mapper.Map<GetCategoryDto>(addedCategory), CategoryMessages.Added);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetCategoryDto>();
            }
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            try
            {
                var result = BusinessRules.Run(await IdMustBeGreaterZero(id));
                if (result != null) return result;

                await _categoryDal.DeleteAsync(id);
                return new SuccessResult(CategoryMessages.Deleted);
            }
            catch (Exception exception)
            {
                return new ErrorResult();
            }
        }

        [CacheAspect]
        public async Task<IDataResult<IList<GetCategoryDto>>> GetAllAsync()
        {
            try
            {
                IList<Category> categories = await _categoryDal.GetAllAsync();

                if (categories.Count == 0) return new ErrorDataResult<IList<GetCategoryDto>>(CategoryMessages.NotFoundData);

                return new SuccessDataResult<IList<GetCategoryDto>>(_mapper.Map<IList<GetCategoryDto>>(categories));
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<IList<GetCategoryDto>>();
            }
        }

        public async Task<IDataResult<GetCategoryDto>> GetAsync(int id)
        {
            try
            {
                var result = BusinessRules.Run(await IdMustBeGreaterZero(id));
                if (result != null) return new ErrorDataResult<GetCategoryDto>(result.Message);

                Category category = await _categoryDal.GetAsync(i => i.Id == id);
                if (category == null) return new SuccessDataResult<GetCategoryDto>(CategoryMessages.NotFoundData);

                return new SuccessDataResult<GetCategoryDto>(_mapper.Map<GetCategoryDto>(category));
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetCategoryDto>();
            }
        }

        public async Task<IResult> UpdateAsync(UpdateCategoryDto updateCategoryDto)
        {
            try
            {
                //kontrol
                var result = BusinessRules.Run(await IdMustBeGreaterZero(updateCategoryDto.Id),
                       await NameMustBeUnique(updateCategoryDto.Name));
                if (result != null) return result;

                //process
                Category oldCategory = await _categoryDal.GetAsync(c => c.Id == updateCategoryDto.Id);
                if (oldCategory == null) return new ErrorResult();

                await _categoryDal.UpdateAsync(_mapper.Map<UpdateCategoryDto, Category>(updateCategoryDto, oldCategory));
                return new SuccessResult(CategoryMessages.Updated);
            }
            catch (Exception exception)
            {
                return new ErrorResult();
            }
        }


        // kontrol
        private async Task<IResult> IdMustBeGreaterZero(int id)
        {
            if (id == 0) return new ErrorResult(GeneralMessages.IdMustBeGreaterZero);
            return new SuccessResult();
        }


        private async Task<IResult> NameMustBeUnique(string name)
        {
            Category SelectedCategory = await _categoryDal.GetAsync(a => a.Name == name);
            if (SelectedCategory != null) return new ErrorResult(GeneralMessages.NameMustBeUnique);
            return new SuccessResult();
        }

        private async Task<IResult> IdNotBeFound(int id)
        {
            Category selectedId = await _categoryDal.GetAsync(c => c.Id == id);
            if (selectedId != null) return new ErrorResult(GeneralMessages.NotFoundData);
            return new SuccessResult();
        }
    }
}
