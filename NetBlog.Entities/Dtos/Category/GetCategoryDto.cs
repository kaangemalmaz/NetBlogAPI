using NetBlog.Core.Entities.Abstract;

namespace NetBlog.Entities.Dtos.Category
{
    // Defensive programming
    public class GetCategoryDto : BaseDto, IDto
    {
        public string Name { get; set; }
    }
}
