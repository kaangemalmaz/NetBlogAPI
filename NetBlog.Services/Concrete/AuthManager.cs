using NetBlog.Business.Abstract;
using NetBlog.Business.Constants;
using NetBlog.Business.Utilities;
using NetBlog.Core.Utilities.Hashing;
using NetBlog.Core.Utilities.Results.Abstract;
using NetBlog.Core.Utilities.Results.Concrete;
using NetBlog.Entities.Dtos;

namespace NetBlog.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;

        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IResult> Login(AuthLoginDto authLoginDto)
        {
            try
            {
                var user = await _userService.GetByEmail(authLoginDto.Email);
                if (user.Data == null) return new ErrorResult(UserMessages.UserNotFound);

                var resultPassword = HashingHelper.VerifyPasswordHash(authLoginDto.Password, user.Data.PasswordSalt, user.Data.PasswordHash);
                if (resultPassword == false) return new ErrorResult(UserMessages.UserPasswordIsWrong);

                return new SuccessResult(UserMessages.UserLoginIsSuccess);
            }
            catch (Exception)
            {
                return new ErrorResult(GeneralMessages.GeneralError);
            }
        }

        public async Task<IResult> Register(AuthRegisterDto authRegisterDto)
        {
            try
            {
                await _userService.AddAsync(authRegisterDto);
                return new SuccessResult(UserMessages.UserRegisterIsSuccess);
            }
            catch (Exception)
            {
                return new ErrorResult(GeneralMessages.GeneralError);
            }
            
        }
    }
}
