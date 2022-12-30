using Microsoft.AspNetCore.Mvc;
using NetBlog.Business.Abstract;
using NetBlog.Core.Entities.Concrete;
using NetBlog.Entities.Dtos.OperaionClaim;

namespace NetBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : ControllerBase
    {
        private readonly IOperationClaimService _operationClaimService;

        public OperationClaimsController(IOperationClaimService operationClaimService)
        {
            _operationClaimService = operationClaimService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _operationClaimService.GetAllAsync();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _operationClaimService.GetAsync(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddOperationClaim addOperationClaim)
        {
            var result = await _operationClaimService.AddAsync(addOperationClaim);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaim updateOperationClaim)
        {
            var result = await _operationClaimService.UpdateAsync(updateOperationClaim);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _operationClaimService.DeleteAsync(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
