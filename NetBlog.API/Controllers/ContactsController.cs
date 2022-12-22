using Microsoft.AspNetCore.Mvc;
using NetBlog.Business.Abstract;
using NetBlog.Entities.Dtos.Contact;

namespace NetBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _contactService.GetAllAsync();
            if (result.ResultStatus == Core.Utilities.Results.ResultStatus.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _contactService.GetAsync(id);
            if (result.ResultStatus == Core.Utilities.Results.ResultStatus.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddContactDto addContactDto)
        {
            var result = await _contactService.AddAsync(addContactDto);
            if (result.ResultStatus == Core.Utilities.Results.ResultStatus.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateContactDto updateContactDto)
        {
            var result = await _contactService.UpdateAsync(updateContactDto);
            if (result.ResultStatus == Core.Utilities.Results.ResultStatus.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _contactService.DeleteAsync(id);
            if (result.ResultStatus == Core.Utilities.Results.ResultStatus.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
