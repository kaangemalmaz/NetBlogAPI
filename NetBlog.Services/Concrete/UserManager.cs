using NetBlog.Business.Abstract;
using NetBlog.Business.Utilities;
using NetBlog.Core.Entities.Concrete;
using NetBlog.Core.Utilities.Hashing;
using NetBlog.Core.Utilities.Results.Abstract;
using NetBlog.Core.Utilities.Results.Concrete;
using NetBlog.DataAccess.Abstract;
using NetBlog.Entities.Dtos;

namespace NetBlog.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IFileService _fileService;

        public UserManager(IUserDal userDal, IFileService fileService)
        {
            _userDal = userDal;
            _fileService = fileService;
        }

        public async Task<IDataResult<User>> AddAsync(AuthRegisterDto authRegisterDto)
        {
            try
            {
                var fileName = await _fileService.FileSaveToServer(authRegisterDto.Image, "./wwwroot/img/");

                User user = CreateUserInfo(authRegisterDto, fileName);

                User addedUser = await _userDal.AddAsync(user);
                return new SuccessDataResult<User>(addedUser);
            }
            catch (Exception)
            {
                return new ErrorDataResult<User>();
            }
            
        }

        private static User CreateUserInfo(AuthRegisterDto authRegisterDto, string fileName)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePassword(authRegisterDto.Password, out passwordSalt, out passwordHash);

            User user = new User
            {
                Email = authRegisterDto.Email,
                ImageUrl = fileName,
                Name = authRegisterDto.Name,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                LastModifiedBy = "",
                LastModifiedDate = null,
            };
            return user;
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            try
            {
                if (id <= 0) return new ErrorResult(GeneralMessages.IdMustBeGreaterZero);

                await _userDal.DeleteAsync(id);
                return new SuccessResult();
            }
            catch (Exception)
            {
                return new ErrorResult();
            }
            
        }

        public async Task<IDataResult<IList<User>>> GetAllAsync()
        {
            try
            {
                var users = await _userDal.GetAllAsync();
                return new SuccessDataResult<IList<User>>(users);
            }
            catch (Exception)
            {
                return new ErrorDataResult<IList<User>>();
            }
        }

        public async Task<IDataResult<User>> GetById(int id)
        {
            try
            {
                var user = await _userDal.GetAsync(u => u.Id == id);
                return new SuccessDataResult<User>(user);
            }
            catch (Exception)
            {
                return new ErrorDataResult<User>();
            }
        }

        public async Task<IResult> UpdateAsync(User user)
        {
            try
            {
                await _userDal.UpdateAsync(user);
                return new SuccessResult();
            }
            catch (Exception)
            {
                return new ErrorResult();
            }
        }

        public async Task<IDataResult<User>> GetByEmail(string email)
        {
            try
            {
                User user = await _userDal.GetAsync(u => u.Email.ToLower() == email.ToLower());
                return new SuccessDataResult<User>(user);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<User>(e.Message);
            }
        }
    }
}
