using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetBlog.Business.Abstract;
using NetBlog.Core.Entities.Concrete;

namespace NetBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : ControllerBase
    {
        private readonly IUserOperationClaimService _userOperationClaimService;

        public UserOperationClaimsController(IUserOperationClaimService userOperationClaimService)
        {
            _userOperationClaimService = userOperationClaimService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userOperationClaimService.GetAllAsync();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _userOperationClaimService.GetAsync(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserOperationClaim userOperationClaim)
        {
            var result = await _userOperationClaimService.AddAsync(userOperationClaim);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserOperationClaim userOperationClaim)
        {
            var result = await _userOperationClaimService.UpdateAsync(userOperationClaim);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _userOperationClaimService.DeleteAsync(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
