using Microsoft.AspNetCore.Mvc;
using NetBlog.Business.Abstract;
using NetBlog.Entities.Dtos.Category;

namespace NetBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        //public IActionResult ResultArchitecture(Core.Utilities.Results.Abstract.IResult result)
        //{
        //    var resultStatus = result.ResultStatus;
        //    if (resultStatus == Core.Utilities.Results.ResultStatus.Warning)
        //        return Ok(result.Message);
        //    else if (resultStatus == Core.Utilities.Results.ResultStatus.Error)
        //        return BadRequest(result.Message);
        //    else
        //        return Ok(result);
        //}


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllAsync();
            if (result.ResultStatus == Core.Utilities.Results.ResultStatus.Success)
                return Ok(result);
            else
                return BadRequest(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _categoryService.GetAsync(id);
            if (result.ResultStatus == Core.Utilities.Results.ResultStatus.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddCategoryDto addCategoryDto)
        {
            var result = await _categoryService.AddAsync(addCategoryDto);
            if (result.ResultStatus == Core.Utilities.Results.ResultStatus.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var result = await _categoryService.UpdateAsync(updateCategoryDto);
            if (result.ResultStatus == Core.Utilities.Results.ResultStatus.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            if (result.ResultStatus == Core.Utilities.Results.ResultStatus.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }


    }
}
