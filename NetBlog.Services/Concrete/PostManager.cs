using AutoMapper;
using NetBlog.Business.Abstract;
using NetBlog.Business.Constants;
using NetBlog.Business.Utilities;
using NetBlog.Business.ValidationRules.FluentValidation.Post;
using NetBlog.Core.Aspects.Validation;
using NetBlog.Core.CrossCuttingConcerns.Validation;
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

        [ValidationAspect(typeof(AddPostDtoValidator))]
        public async Task<IDataResult<GetPostDto>> AddAsync(AddPostDto addPostDto)
        {
            try
            {
                //AddPostDtoValidator rules = new AddPostDtoValidator();
                //rules.Validate(addPostDto);

                //AddPostDtoValidator rules = new AddPostDtoValidator();
                //ValidationTools.Validation(rules, addPostDto);

                Post addedPost = await _postDal.AddAsync(_mapper.Map<Post>(addPostDto));
                GetPostDto getPostDto = _mapper.Map<GetPostDto>(addedPost);
                return new SuccessDataResult<GetPostDto>(getPostDto, PostMessages.Added);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetPostDto>();
            }
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            try
            {
                if (id == 0) return new ErrorResult(GeneralMessages.IdMustBeGreaterZero);
                await _postDal.DeleteAsync(id);
                return new SuccessResult(PostMessages.Deleted);
            }
            catch (Exception exception)
            {
                return new ErrorResult();
            }
        }

        public async Task<IDataResult<IList<GetPostDto>>> GetAllAsync()
        {
            try
            {
                IList<Post> posts = await _postDal.GetAllAsync();

                if (posts.Count == 0) return new ErrorDataResult<IList<GetPostDto>>(GeneralMessages.NotFoundData);

                return new SuccessDataResult<IList<GetPostDto>>(_mapper.Map<IList<GetPostDto>>(posts));
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<IList<GetPostDto>>();
            }
        }

        public async Task<IDataResult<GetPostDto>> GetAsync(int id)
        {
            try
            {
                if (id == 0) return new ErrorDataResult<GetPostDto>(GeneralMessages.IdMustBeGreaterZero);

                Post post = await _postDal.GetAsync(i => i.Id == id);

                if (post == null) return new ErrorDataResult<GetPostDto>(GeneralMessages.NotFoundData);

                return new SuccessDataResult<GetPostDto>(_mapper.Map<GetPostDto>(post));
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetPostDto>();
            }
        }

        public async Task<IResult> UpdateAsync(UpdatePostDto updatePostDto)
        {
            try
            {
                // kontrol
                if (updatePostDto.Id == 0) return new ErrorResult(GeneralMessages.IdMustBeGreaterZero);

                Post oldPost = await _postDal.GetAsync(p => p.Id == updatePostDto.Id);
                if (oldPost == null) return new ErrorResult();

                await _postDal.UpdateAsync(_mapper.Map<UpdatePostDto, Post>(updatePostDto, oldPost));
                return new SuccessResult(PostMessages.Updated);
            }
            catch (Exception exception)
            {
                return new ErrorResult();
            }
        }
    }
}
