using AutoMapper;
using NetBlog.Business.Abstract;
using NetBlog.Business.Utilities;
using NetBlog.Core.Utilities.Results.Abstract;
using NetBlog.Core.Utilities.Results.Concrete;
using NetBlog.DataAccess.Abstract;
using NetBlog.Entities.Concrete;
using NetBlog.Entities.Dtos.Post;

namespace NetBlog.Business.Concrete
{
    public class PostManager : IPostService
    {
        // LOOSELY COUPLING
        private readonly IPostDal _postDal;
        private readonly IMapper _mapper;

        public PostManager(IPostDal postDal, IMapper mapper)
        {
            _postDal = postDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<GetPostDto>> AddAsync(AddPostDto addPostDto)
        {
            try
            {
                Post addedPost = await _postDal.AddAsync(_mapper.Map<Post>(addPostDto));
                GetPostDto getPostDto = _mapper.Map<GetPostDto>(addedPost);
                return new DataResult<GetPostDto>(getPostDto, Core.Utilities.Results.ResultStatus.Success);
            }
            catch (Exception exception)
            {
                return new DataResult<GetPostDto>(null, Core.Utilities.Results.ResultStatus.Error);
            }
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            try
            {
                if (id == 0) throw new Exception(Messages.GeneralMessages.IdMustBeGreaterZero());
                await _postDal.DeleteAsync(id);
                return new Result(Core.Utilities.Results.ResultStatus.Success);
            }
            catch (Exception exception)
            {
                return new Result(Core.Utilities.Results.ResultStatus.Error, exception.Message);
                //throw new Exception(exception.Message);
            }
        }

        public async Task<IDataResult<IList<GetPostDto>>> GetAllAsync()
        {
            try
            {
                IList<Post> posts = await _postDal.GetAllAsync();

                if (posts.Count == 0) throw new Exception(Messages.GeneralMessages.NotFoundData(Messages.EntityTypes.Post));

                return new DataResult<IList<GetPostDto>>(_mapper.Map<IList<GetPostDto>>(posts), Core.Utilities.Results.ResultStatus.Success);
            }
            catch (Exception exception)
            {
                return new DataResult<IList<GetPostDto>>(null, Core.Utilities.Results.ResultStatus.Error);
                //throw new Exception(exception.Message);
            }
        }

        public async Task<IDataResult<GetPostDto>> GetAsync(int id)
        {
            try
            {
                if (id == 0) throw new Exception(Messages.GeneralMessages.IdMustBeGreaterZero());

                Post post = await _postDal.GetAsync(i => i.Id == id);

                if (post == null) throw new Exception(Messages.GeneralMessages.NotFoundData(Messages.EntityTypes.Post));

                return new DataResult<GetPostDto>(_mapper.Map<GetPostDto>(post), Core.Utilities.Results.ResultStatus.Success);
            }
            catch (Exception exception)
            {
                return new DataResult<GetPostDto>(null, Core.Utilities.Results.ResultStatus.Error);
                //throw new Exception(exception.Message);
            }
        }

        public async Task<IResult> UpdateAsync(UpdatePostDto updatePostDto)
        {
            try
            {
                // kontrol
                if (updatePostDto.Id == 0) throw new Exception(Messages.GeneralMessages.IdMustBeGreaterZero());

                Post oldPost = await _postDal.GetAsync(p => p.Id == updatePostDto.Id);
                if (oldPost == null) return new Result(Core.Utilities.Results.ResultStatus.Error);

                await _postDal.UpdateAsync(_mapper.Map<UpdatePostDto, Post>(updatePostDto, oldPost));
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
