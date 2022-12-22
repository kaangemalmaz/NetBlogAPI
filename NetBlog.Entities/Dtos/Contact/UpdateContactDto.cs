using NetBlog.Core.Entities.Abstract;

namespace NetBlog.Entities.Dtos.Contact
{
    // Defensive programming
    public class UpdateContactDto : IDto
    {
        public int Id { get; set; }
        public string LastModifiedBy { get; set; }

        public string Email { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
