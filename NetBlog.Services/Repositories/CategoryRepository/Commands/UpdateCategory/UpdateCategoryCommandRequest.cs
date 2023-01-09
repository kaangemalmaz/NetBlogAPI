using MediatR;
using NetBlog.Core.Utilities.Results.Abstract;

namespace NetBlog.Business.Repositories.CategoryRepository.Commands.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest<IResult>
    {
        public int Id { get; set; }
        public string LastModifiedBy { get; set; }
        public string Name { get; set; }
    }
}
