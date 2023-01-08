using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetBlog.Business.Repositories.EmailParameterRepository;
using NetBlog.Core.Entities.Concrete;

namespace NetBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailParametersController : ControllerBase
    {
        private readonly IEmailParameterService _emailParameterService;

        public EmailParametersController(IEmailParameterService emailParameterService)
        {
            _emailParameterService = emailParameterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _emailParameterService.GetAllAsync();
            if(result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _emailParameterService.GetAsync(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(EmailParameter emailParameter, string body, string subject, string emails)
        {
            var result = await _emailParameterService.SendEmail(emailParameter, body, subject, emails);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
