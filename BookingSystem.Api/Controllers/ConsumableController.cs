using BookingSystem.Application.Features.Consumables.Commands.CreateConsumable;
using BookingSystem.Application.Features.Consumables.Commands.CreateConsumableCategory;
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
