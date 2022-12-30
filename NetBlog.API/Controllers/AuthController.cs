using Microsoft.AspNetCore.Mvc;
using NetBlog.Business.Abstract;
using NetBlog.Entities.Dtos;

namespace NetBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] AuthRegisterDto authRegisterDto)
        {
            var result = await _authService.Register(authRegisterDto);
            if(!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(AuthLoginDto authLoginDto)
        {
            var result = await _authService.Login(authLoginDto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }
    }
}
