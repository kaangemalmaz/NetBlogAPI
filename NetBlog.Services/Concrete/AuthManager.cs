using Microsoft.IdentityModel.Tokens;
using NetBlog.Business.Abstract;
using NetBlog.Business.Constants;
using NetBlog.Business.Utilities;
using NetBlog.Core.Utilities.Hashing;
using NetBlog.Core.Utilities.Results.Abstract;
using NetBlog.Core.Utilities.Results.Concrete;
using NetBlog.Core.Utilities.Security.Jwt;
using NetBlog.Entities.Dtos;

namespace NetBlog.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHandler _tokenHandler;

        public AuthManager(IUserService userService, ITokenHandler tokenHandler)
        {
            _userService = userService;
            _tokenHandler = tokenHandler;
        }

        public async Task<IDataResult<Token>> Login(AuthLoginDto authLoginDto)
        {
            try
            {
                var user = await _userService.GetByEmail(authLoginDto.Email);
                if (user.Data == null) return new ErrorDataResult<Token>(UserMessages.UserNotFound);

                var resultPassword = HashingHelper.VerifyPasswordHash(authLoginDto.Password, user.Data.PasswordSalt, user.Data.PasswordHash);
                if (resultPassword == false) return new ErrorDataResult<Token>(UserMessages.UserPasswordIsWrong);

                var operationClaims = await _userService.GetUserOperationClaims(user.Data.Id);
                var result = _tokenHandler.CreateToken(user.Data, operationClaims.Data);

                return new SuccessDataResult<Token>(result, UserMessages.UserLoginIsSuccess);
            }
            catch (Exception)
            {
                return new ErrorDataResult<Token>(GeneralMessages.GeneralError);
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
