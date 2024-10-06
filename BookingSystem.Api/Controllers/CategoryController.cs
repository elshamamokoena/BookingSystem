using BookingSystem.Application.Features.Categories.GetCategories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name ="GetCategoriesAsync")]
        public async Task<ActionResult<IEnumerable<CategoryListVm>>> GetCategoriesAsync()
        {
            var dtos = await _mediator.Send(new GetCategoriesQuery());
            return Ok(dtos);
        }
    }
}
