using NetBlog.Core.Utilities.Results.Abstract;
using NetBlog.Entities.Dtos.Contact;

namespace NetBlog.Business.Repositories.ContactRepository
{
    public interface IContactService
    {
        Task<IDataResult<IList<GetContactDto>>> GetAllAsync();
        Task<IDataResult<GetContactDto>> GetAsync(int id);
        Task<IDataResult<GetContactDto>> AddAsync(AddContactDto addContactDto);
        Task<IResult> UpdateAsync(UpdateContactDto updateContactDto);
        Task<IResult> DeleteAsync(int id);
    }
}
