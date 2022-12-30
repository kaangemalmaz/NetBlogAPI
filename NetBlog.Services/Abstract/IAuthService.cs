using NetBlog.Core.Utilities.Results.Abstract;
using NetBlog.Entities.Dtos;

namespace NetBlog.Business.Abstract
{
    public interface IAuthService
    {
        Task<IResult> Register(AuthRegisterDto authRegisterDto);
        Task<IResult> Login(AuthLoginDto authLoginDto);
    }
}
