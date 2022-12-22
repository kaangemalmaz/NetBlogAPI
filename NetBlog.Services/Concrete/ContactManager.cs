using AutoMapper;
using NetBlog.Business.Abstract;
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
                return new DataResult<GetContactDto>(_mapper.Map<GetContactDto>(addedContact), Core.Utilities.Results.ResultStatus.Success);
            }
            catch (Exception exception)
            {
                return new DataResult<GetContactDto>(null, Core.Utilities.Results.ResultStatus.Error);
            }
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            try
            {
                if (id == 0) throw new Exception(Messages.GeneralMessages.IdMustBeGreaterZero());

                await _contactDal.DeleteAsync(id);
                return new Result(Core.Utilities.Results.ResultStatus.Success);
            }
            catch (Exception exception)
            {
                return new Result(Core.Utilities.Results.ResultStatus.Error);
                //throw new Exception(exception.Message);
            }
        }

        public async Task<IDataResult<IList<GetContactDto>>> GetAllAsync()
        {
            try
            {
                IList<Contact> contacts = await _contactDal.GetAllAsync();

                if (contacts.Count == 0) throw new Exception(Messages.GeneralMessages.NotFoundData(Messages.EntityTypes.Contact));

                return new DataResult<IList<GetContactDto>>(_mapper.Map<IList<GetContactDto>>(contacts), Core.Utilities.Results.ResultStatus.Success);
            }
            catch (Exception exception)
            {
                return new DataResult<IList<GetContactDto>>(null, Core.Utilities.Results.ResultStatus.Error);
                //throw new Exception(exception.Message);
            }
        }

        public async Task<IDataResult<GetContactDto>> GetAsync(int id)
        {
            try
            {
                if (id == 0) throw new Exception(Messages.GeneralMessages.IdMustBeGreaterZero());

                Contact contact = await _contactDal.GetAsync(i => i.Id == id);

                if (contact == null) throw new Exception(Messages.GeneralMessages.NotFoundData(Messages.EntityTypes.Contact));

                return new DataResult<GetContactDto>(_mapper.Map<GetContactDto>(contact), Core.Utilities.Results.ResultStatus.Success);
            }
            catch (Exception exception)
            {
                return new DataResult<GetContactDto>(null, Core.Utilities.Results.ResultStatus.Error);
                //throw new Exception(exception.Message);
            }
        }

        public async Task<IResult> UpdateAsync(UpdateContactDto updateContactDto)
        {
            try
            {
                //kontrol
                if (updateContactDto.Id == 0) throw new Exception(Messages.GeneralMessages.IdMustBeGreaterZero());

                Contact oldContact = await _contactDal.GetAsync(c => c.Id == updateContactDto.Id);
                if (oldContact == null) return new Result(Core.Utilities.Results.ResultStatus.Error);

                await _contactDal.UpdateAsync(_mapper.Map<UpdateContactDto, Contact>(updateContactDto, oldContact));
                return new Result(Core.Utilities.Results.ResultStatus.Success);
            }
            catch (Exception exception)
            {
                return new Result(Core.Utilities.Results.ResultStatus.Error);
                //throw new Exception(exception.Message);
            }
        }
    }
}
