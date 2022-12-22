using AutoMapper;
using NetBlog.Business.Abstract;
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
                return new DataResult<GetCommentDto>(_mapper.Map<GetCommentDto>(addedComment), Core.Utilities.Results.ResultStatus.Success);
            }
            catch (Exception exception)
            {
                return new DataResult<GetCommentDto>(null, Core.Utilities.Results.ResultStatus.Error);
            }
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            try
            {
                if (id == 0) throw new Exception(Messages.GeneralMessages.IdMustBeGreaterZero());

                await _commentDal.DeleteAsync(id);
                return new Result(Core.Utilities.Results.ResultStatus.Success);
            }
            catch (Exception exception)
            {
                return new Result(Core.Utilities.Results.ResultStatus.Error);
                //throw new Exception(exception.Message);
            }
        }

        public async Task<IDataResult<IList<GetCommentDto>>> GetAllAsync()
        {
            try
            {
                IList<Comment> comments = await _commentDal.GetAllAsync();

                if (comments.Count == 0) throw new Exception(Messages.GeneralMessages.NotFoundData(Messages.EntityTypes.Comment));
                //return new DataResult<IList<GetCommentDto>>(null, Core.Utilities.Results.ResultStatus.Warning);

                return new DataResult<IList<GetCommentDto>>(_mapper.Map<IList<GetCommentDto>>(comments), Core.Utilities.Results.ResultStatus.Success);
            }
            catch (Exception exception)
            {
                return new DataResult<IList<GetCommentDto>>(null, Core.Utilities.Results.ResultStatus.Error);
                //throw new Exception(exception.Message);
            }
        }

        public async Task<IDataResult<GetCommentDto>> GetAsync(int id)
        {
            try
            {
                if (id == 0) throw new Exception(Messages.GeneralMessages.IdMustBeGreaterZero());

                Comment comment = await _commentDal.GetAsync(i => i.Id == id);

                if (comment == null) throw new Exception(Messages.GeneralMessages.NotFoundData(Messages.EntityTypes.Comment));

                return new DataResult<GetCommentDto>(_mapper.Map<GetCommentDto>(comment), Core.Utilities.Results.ResultStatus.Success);
            }
            catch (Exception exception)
            {
                return new DataResult<GetCommentDto>(null, Core.Utilities.Results.ResultStatus.Error);
                //throw new Exception(exception.Message);
            }
        }

        public async Task<IResult> UpdateAsync(UpdateCommentDto updateCommentDto)
        {
            try
            {
                //kontrol
                if (updateCommentDto.Id == 0) throw new Exception(Messages.GeneralMessages.IdMustBeGreaterZero());

                Comment oldComment = await _commentDal.GetAsync(c => c.Id == updateCommentDto.Id);
                if (oldComment == null) return new Result(Core.Utilities.Results.ResultStatus.Error);

                await _commentDal.UpdateAsync(_mapper.Map<UpdateCommentDto, Comment>(updateCommentDto, oldComment));
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
