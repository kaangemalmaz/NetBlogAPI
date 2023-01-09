using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NetBlog.API.Controllers
{
    public class CustomBaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
