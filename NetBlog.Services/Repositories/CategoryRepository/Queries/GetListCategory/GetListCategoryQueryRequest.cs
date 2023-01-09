using MediatR;
using NetBlog.Entities.Dtos.Category;

namespace NetBlog.Business.Repositories.CategoryRepository.Queries.GetListCategory
{
    public class GetListCategoryQueryRequest : IRequest<List<GetCategoryDto>>
    {
    }
}
