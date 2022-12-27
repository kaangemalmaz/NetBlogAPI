using AutoMapper;
using NetBlog.Business.Abstract;
using NetBlog.Business.Constants;
using NetBlog.Business.Utilities;
using NetBlog.Core.Utilities.Results.Abstract;
using NetBlog.Core.Utilities.Results.Concrete;
using NetBlog.DataAccess.Abstract;
using NetBlog.Entities.Concrete;
using NetBlog.Entities.Dtos.Contact;

namespace NetBlog.Business.Concrete
{
    public class ContactManager : IContactService
    {
        // loose coupling
        // referans tutucu
        // service collection değişirse burası otomatik değişiyor.
        private readonly IContactDal _contactDal;
        private readonly IMapper _mapper;

        public ContactManager(IContactDal contactDal, IMapper mapper)
        {
            _contactDal = contactDal;
            _mapper = mapper;
        }


        public async Task<IDataResult<GetContactDto>> AddAsync(AddContactDto addContactDto)
        {
            try
            {
                Contact addedContact = await _contactDal.AddAsync(_mapper.Map<Contact>(addContactDto));
                return new SuccessDataResult<GetContactDto>(_mapper.Map<GetContactDto>(addedContact), ContactMessages.Added);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetContactDto>();
            }
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            try
            {
                if (id == 0) return new ErrorResult(GeneralMessages.IdMustBeGreaterZero);

                await _contactDal.DeleteAsync(id);
                return new SuccessResult();
            }
            catch (Exception exception)
            {
                return new ErrorResult();
                //throw new Exception(exception.Message);
            }
        }

        public async Task<IDataResult<IList<GetContactDto>>> GetAllAsync()
        {
            try
            {
                IList<Contact> contacts = await _contactDal.GetAllAsync();

                if (contacts.Count == 0) return new ErrorDataResult<IList<GetContactDto>>(GeneralMessages.NotFoundData);

                return new SuccessDataResult<IList<GetContactDto>>(_mapper.Map<IList<GetContactDto>>(contacts));
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<IList<GetContactDto>>();
            }
        }

        public async Task<IDataResult<GetContactDto>> GetAsync(int id)
        {
            try
            {
                if (id == 0) return new ErrorDataResult<GetContactDto>(GeneralMessages.IdMustBeGreaterZero);

                Contact contact = await _contactDal.GetAsync(i => i.Id == id);

                if (contact == null) return new ErrorDataResult<GetContactDto>(GeneralMessages.NotFoundData);

                return new SuccessDataResult<GetContactDto>(_mapper.Map<GetContactDto>(contact));
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetContactDto>();
            }
        }

        public async Task<IResult> UpdateAsync(UpdateContactDto updateContactDto)
        {
            try
            {
                //kontrol
                if (updateContactDto.Id == 0) return new ErrorResult(GeneralMessages.IdMustBeGreaterZero);

                Contact oldContact = await _contactDal.GetAsync(c => c.Id == updateContactDto.Id);
                if (oldContact == null) return new ErrorResult();

                await _contactDal.UpdateAsync(_mapper.Map<UpdateContactDto, Contact>(updateContactDto, oldContact));
                return new SuccessResult();
            }
            catch (Exception exception)
            {
                return new ErrorResult();
            }
        }
    }
}
