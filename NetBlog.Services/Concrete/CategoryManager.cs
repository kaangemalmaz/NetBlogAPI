using AutoMapper;
using NetBlog.Business.Abstract;
using NetBlog.Business.Utilities;
using NetBlog.Core.Utilities.Results;
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

        public async Task<IDataResult<GetCategoryDto>> AddAsync(AddCategoryDto addCategoryDto)
        {
            try
            {
                //kontrol
                Category category = await _categoryDal.GetAsync(a => a.Name == addCategoryDto.Name);
                if (category != null) throw new Exception(Messages.GeneralMessages.NameMustBeUnique(Messages.EntityTypes.Categories));

                //process
                Category addedCategory = await _categoryDal.AddAsync(_mapper.Map<Category>(addCategoryDto));
                return new DataResult<GetCategoryDto>(_mapper.Map<GetCategoryDto>(addedCategory), Core.Utilities.Results.ResultStatus.Success);
            }
            catch (Exception exception)
            {
                return new DataResult<GetCategoryDto>(null, Core.Utilities.Results.ResultStatus.Error, exception.Message);
            }
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            try
            {
                if (id == 0) throw new Exception(Messages.GeneralMessages.IdMustBeGreaterZero());
                await _categoryDal.DeleteAsync(id);
                return new Result(Core.Utilities.Results.ResultStatus.Success);
            }
            catch (Exception exception)
            {
                return new Result(Core.Utilities.Results.ResultStatus.Error, exception.Message);
                //throw new Exception(exception.Message);
            }
        }

        public async Task<IDataResult<IList<GetCategoryDto>>> GetAllAsync()
        {
            try
            {
                IList<Category> categories = await _categoryDal.GetAllAsync();

                if (categories.Count == 0)
                    throw new Exception(Messages.GeneralMessages.NotFoundData(Messages.EntityTypes.Categories));
                //return new DataResult<IList<GetCategoryDto>>(null, Core.Utilities.Results.ResultStatus.Warning);

                return new DataResult<IList<GetCategoryDto>>(_mapper.Map<IList<GetCategoryDto>>(categories), ResultStatus.Success);
            }
            catch (Exception exception)
            {
                return new DataResult<IList<GetCategoryDto>>(null, Core.Utilities.Results.ResultStatus.Error);
                //throw new Exception(exception.Message);
            }
        }

        public async Task<IDataResult<GetCategoryDto>> GetAsync(int id)
        {
            try
            {
                if (id == 0) throw new Exception(Messages.GeneralMessages.IdMustBeGreaterZero());

                Category category = await _categoryDal.GetAsync(i => i.Id == id);

                if (category == null) throw new Exception(Messages.GeneralMessages.NotFoundData(Messages.EntityTypes.Categories));
                //return new DataResult<GetCategoryDto>(null, Core.Utilities.Results.ResultStatus.Warning);

                return new DataResult<GetCategoryDto>(_mapper.Map<GetCategoryDto>(category), Core.Utilities.Results.ResultStatus.Success);
            }
            catch (Exception exception)
            {
                return new DataResult<GetCategoryDto>(null, Core.Utilities.Results.ResultStatus.Error, exception.Message);
                //throw new Exception(exception.Message);
            }
        }

        public async Task<IResult> UpdateAsync(UpdateCategoryDto updateCategoryDto)
        {
            try
            {
                //kontrol
                if (updateCategoryDto.Id == 0) throw new Exception(Messages.GeneralMessages.IdMustBeGreaterZero());

                Category category = await _categoryDal.GetAsync(a => a.Name == updateCategoryDto.Name);
                if (category != null) throw new Exception(Messages.GeneralMessages.NameMustBeUnique(Messages.EntityTypes.Categories));

                //process
                Category oldCategory = await _categoryDal.GetAsync(c => c.Id == updateCategoryDto.Id);
                if (oldCategory == null) return new Result(Core.Utilities.Results.ResultStatus.Error);

                await _categoryDal.UpdateAsync(_mapper.Map<UpdateCategoryDto, Category>(updateCategoryDto, oldCategory));
                return new Result(Core.Utilities.Results.ResultStatus.Success);
            }
            catch (Exception exception)
            {
                return new Result(Core.Utilities.Results.ResultStatus.Error);
                //throw new Exception(exception.Message);
            }
        }
    }
}
