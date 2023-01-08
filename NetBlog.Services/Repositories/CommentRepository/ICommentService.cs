using NetBlog.Core.Utilities.Results.Abstract;
using NetBlog.Entities.Dtos.Comment;

namespace NetBlog.Business.Repositories.CommentRepository
{
    public interface ICommentService
    {
        Task<IDataResult<IList<GetCommentDto>>> GetAllAsync();
        Task<IDataResult<GetCommentDto>> GetAsync(int id);
        Task<IDataResult<GetCommentDto>> AddAsync(AddCommentDto addCommentDto);
        Task<IResult> UpdateAsync(UpdateCommentDto updateCommentDto);
        Task<IResult> DeleteAsync(int id);
    }
}
