using MediatR;
using NetBlog.Entities.Dtos.Category;

namespace NetBlog.Business.Repositories.CategoryRepository.Queries.GetByIdCategory
{
    public class GetByIdQueryRequest : IRequest<GetCategoryDto>
    {
        public int Id { get; set; }
    }
}
