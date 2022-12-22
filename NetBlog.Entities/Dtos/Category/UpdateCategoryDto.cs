using NetBlog.Core.Entities.Abstract;

namespace NetBlog.Entities.Dtos.Category
{
    // Defensive programming
    public class UpdateCategoryDto : IDto
    {
        public int Id { get; set; }
        public string LastModifiedBy { get; set; }
        public string Name { get; set; }
    }
}
