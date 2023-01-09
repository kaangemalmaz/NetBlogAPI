using MediatR;
using NetBlog.Core.Utilities.Results.Abstract;

namespace NetBlog.Business.Repositories.CategoryRepository.Commands.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest<IResult>
    {
        public string CreatedBy { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
    }
}
