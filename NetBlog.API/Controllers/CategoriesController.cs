using Microsoft.AspNetCore.Mvc;
using NetBlog.Business.Repositories.CategoryRepository;
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


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllAsync();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _categoryService.GetAsync(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddCategoryDto addCategoryDto)
        {
            var result = await _categoryService.AddAsync(addCategoryDto);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var result = await _categoryService.UpdateAsync(updateCategoryDto);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }


    }
}
