using NetBlog.Core.Entities.Abstract;

namespace NetBlog.Entities.Dtos.Contact
{
    // Defensive programming
    public class GetContactDto : BaseDto, IDto
    {

        public string Email { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

    }
}
