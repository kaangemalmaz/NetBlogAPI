using NetBlog.Core.Utilities.Results.Abstract;
using NetBlog.Entities.Dtos.Post;

namespace NetBlog.Business.Repositories.PostRepository
{
    public interface IPostService
    {
        Task<IDataResult<IList<GetPostDto>>> GetAllAsync();
        Task<IDataResult<GetPostDto>> GetAsync(int id);
        Task<IDataResult<GetPostDto>> AddAsync(AddPostDto addPostDto);
        Task<IResult> UpdateAsync(UpdatePostDto updatePostDto);
        Task<IResult> DeleteAsync(int id);
    }
}
