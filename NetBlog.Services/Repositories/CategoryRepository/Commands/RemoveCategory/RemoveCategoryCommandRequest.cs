using MediatR;
using NetBlog.Core.Utilities.Results.Abstract;

namespace NetBlog.Business.Repositories.CategoryRepository.Commands.RemoveCategory
{
    public class RemoveCategoryCommandRequest : IRequest<IResult>
    {
        public int Id { get; set; }
    }
}
