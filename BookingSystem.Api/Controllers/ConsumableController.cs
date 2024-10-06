using BookingSystem.Application.Features.Consumables.Commands.CreateConsumable;
using BookingSystem.Application.Features.Consumables.Commands.CreateConsumableCategory;
using BookingSystem.Application.Features.Consumables.Queries.GetConsumables;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/consumables")]
    public class ConsumableController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ConsumableController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetConsumablesAsync")]
        public async Task<ActionResult<IEnumerable<ConsumableListVm>>> GetConsumablesAsync([FromQuery] GetConsumablesQuery query)
        {
            var dtos = await _mediator.Send(query);
            return Ok(dtos);
        }

        [HttpPost(Name = "CreateConsumableAsync")]
        public async Task<ActionResult<CreateConsumableCommandResponse>> 
            CreateConsumableAsync([FromBody] CreateConsumableCommand createConsumableCommand)
        {
            return Ok(await _mediator.Send(createConsumableCommand));
        }

        [HttpPost("categories",Name = "CreateConsumableCategoryAsync")]
        public async Task<ActionResult<CreateConsumableCategoryCommandResponse>> 
            CreateConsumableCategoryAsync([FromBody] CreateConsumableCategoryCommand createConsumableCategoryCommand)
        {
            return Ok(await _mediator.Send(createConsumableCategoryCommand));
        }
   
    }
}
