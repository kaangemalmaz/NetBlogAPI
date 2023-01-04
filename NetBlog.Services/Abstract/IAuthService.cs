using NetBlog.Core.Utilities.Results.Abstract;
using NetBlog.Core.Utilities.Security.Jwt;
using NetBlog.Entities.Dtos;

namespace NetBlog.Business.Abstract
{
    public interface IAuthService
    {
        Task<IResult> Register(AuthRegisterDto authRegisterDto);
        Task<IDataResult<Token>> Login(AuthLoginDto authLoginDto);
    }
}
