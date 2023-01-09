using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetBlog.Business.Repositories.CategoryRepository.Commands.CreateCategory;
using NetBlog.Business.Repositories.CategoryRepository.Commands.RemoveCategory;
using NetBlog.Business.Repositories.CategoryRepository.Commands.UpdateCategory;
using NetBlog.Business.Repositories.CategoryRepository.Queries.GetByIdCategory;
using NetBlog.Business.Repositories.CategoryRepository.Queries.GetListCategory;

namespace NetBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomBaseController
    {
        //private readonly IMediator Mediator;

        //public CategoriesController(IMediator mediator)
        //{
        //    Mediator = mediator;
        //}

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetListCategoryQueryRequest());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(new GetByIdQueryRequest() { Id = id});
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            var result = await Mediator.Send(createCategoryCommandRequest);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            var result = await Mediator.Send(updateCategoryCommandRequest);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await Mediator.Send(new RemoveCategoryCommandRequest() { Id = id });
            return Ok(result);
        }
    }
}
