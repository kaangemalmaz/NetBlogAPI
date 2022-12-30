using NetBlog.Core.Entities.Concrete;
using NetBlog.Core.Utilities.Results.Abstract;
using NetBlog.Entities.Dtos;

namespace NetBlog.Business.Abstract
{
    public interface IUserService 
    {
        Task<IDataResult<IList<User>>> GetAllAsync();
        Task<IDataResult<User>> GetById(int id);
        Task<IDataResult<User>> GetByEmail(string email);
        Task<IDataResult<User>> AddAsync(AuthRegisterDto authRegisterDto);
        Task<IResult> UpdateAsync(User user);
        Task<IResult> DeleteAsync(int id);
    }
}
