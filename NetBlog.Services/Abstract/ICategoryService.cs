using NetBlog.Core.Utilities.Results.Abstract;
using NetBlog.Entities.Dtos.Category;

namespace NetBlog.Business.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<IList<GetCategoryDto>>> GetAllAsync();
        Task<IDataResult<GetCategoryDto>> GetAsync(int id);
        Task<IDataResult<GetCategoryDto>> AddAsync(AddCategoryDto addCategoryDto);
        Task<IResult> UpdateAsync(UpdateCategoryDto updateCategoryDto);
        Task<IResult> DeleteAsync(int id);
    }
}
