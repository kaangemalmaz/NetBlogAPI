using AutoMapper;
using NetBlog.Business.Abstract;
using NetBlog.Business.Constants;
using NetBlog.Business.Utilities;
using NetBlog.Core.Utilities.Results.Abstract;
using NetBlog.Core.Utilities.Results.Concrete;
using NetBlog.DataAccess.Abstract;
using NetBlog.Entities.Concrete;
using NetBlog.Entities.Dtos.Comment;

namespace NetBlog.Business.Concrete
{
    public class CommentManager : ICommentService
    {
        // loose coupling
        // referans tutucu
        // service collection değişirse burası otomatik değişiyor.
        private readonly ICommentDal _commentDal;
        private readonly IMapper _mapper;

        public CommentManager(ICommentDal commentDal, IMapper mapper)
        {
            _commentDal = commentDal;
            _mapper = mapper;
        }

        public async Task<IDataResult<GetCommentDto>> AddAsync(AddCommentDto addCommentDto)
        {
            try
            {
                Comment addedComment = await _commentDal.AddAsync(_mapper.Map<Comment>(addCommentDto));
                return new SuccessDataResult<GetCommentDto>(_mapper.Map<GetCommentDto>(addedComment), CommentMessages.Added);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetCommentDto>();
            }
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            try
            {
                if (id == 0) return new ErrorResult(GeneralMessages.IdMustBeGreaterZero);

                await _commentDal.DeleteAsync(id);
                return new SuccessResult(CommentMessages.Deleted);
            }
            catch (Exception exception)
            {
                return new ErrorResult();
            }
        }

        public async Task<IDataResult<IList<GetCommentDto>>> GetAllAsync()
        {
            try
            {
                IList<Comment> comments = await _commentDal.GetAllAsync();

                if (comments.Count == 0) return new ErrorDataResult<IList<GetCommentDto>>(GeneralMessages.NotFoundData);

                return new SuccessDataResult<IList<GetCommentDto>>(_mapper.Map<IList<GetCommentDto>>(comments));
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<IList<GetCommentDto>>();
            }
        }

        public async Task<IDataResult<GetCommentDto>> GetAsync(int id)
        {
            try
            {
                if (id == 0) return new ErrorDataResult<GetCommentDto>(GeneralMessages.IdMustBeGreaterZero);

                Comment comment = await _commentDal.GetAsync(i => i.Id == id);

                if (comment == null) return new ErrorDataResult<GetCommentDto>(GeneralMessages.NotFoundData);

                return new SuccessDataResult<GetCommentDto>(_mapper.Map<GetCommentDto>(comment));
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetCommentDto>();
            }
        }

        public async Task<IResult> UpdateAsync(UpdateCommentDto updateCommentDto)
        {
            try
            {
                //kontrol
                if (updateCommentDto.Id == 0) return new ErrorResult(GeneralMessages.IdMustBeGreaterZero);

                Comment oldComment = await _commentDal.GetAsync(c => c.Id == updateCommentDto.Id);
                if (oldComment == null) return new ErrorResult();

                await _commentDal.UpdateAsync(_mapper.Map<UpdateCommentDto, Comment>(updateCommentDto, oldComment));
                return new SuccessResult(CommentMessages.Updated);
            }
            catch (Exception exception)
            {
                return new ErrorResult();
            }
        }
    }
}
