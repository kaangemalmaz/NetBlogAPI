using NetBlog.Core.Entities.Abstract;

namespace NetBlog.Entities.Dtos.Category
{
    // Defensive programming
    public class AddCategoryDto : IDto
    {
        public string CreatedBy { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
    }
}
