using BookingSystem.Application.Features.ConsumableCategories.Queries.GetConsumableCategories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Api.Controllers
{
    [Route("api/consumables/categories")]
    [ApiController]
    public class ConsumableCategoryController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ConsumableCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllConsumableCategories")]
        public async Task<ActionResult<IEnumerable<ConsumableCategoryListVm>>> GetAllConsumableCategories()
        {
            var dtos = await _mediator.Send(new GetConsumableCategoriesQuery());
            return Ok(dtos);
        }
    }
}
