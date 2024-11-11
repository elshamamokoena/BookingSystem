using BookingSystem.Application.Features.ConsumableCategories.Commands;
using BookingSystem.Application.Features.ConsumableCategories.Queries.GetConsumableCategories;
using BookingSystem.Application.Features.Consumables.Commands.CreateConsumable;
using BookingSystem.Application.Features.Consumables.Commands.DeleteConsumable;
using BookingSystem.Application.Features.Consumables.Commands.UpdateConsumable;
using BookingSystem.Application.Features.Consumables.Queries.GetConsumable;
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

        [HttpGet("list",Name = "GetConsumablesAsync")]
        public async Task<ActionResult<ConsumableListVm>> GetConsumablesAsync([FromQuery] GetConsumablesQuery query)
        {
            var dtos = await _mediator.Send(query);
            return Ok(dtos);
        }

        [HttpGet(Name ="GetConsumableAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ConsumableVm>> GetConsumableAsync([FromQuery]GetConsumableQuery query)
        {
            var dto = await _mediator.Send(query);
            return Ok(dto);

        }

        [HttpPost(Name = "CreateConsumableAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<Guid>> CreateConsumableAsync([FromBody] CreateConsumableCommand createConsumableCommand)
        {
            return Ok(await _mediator.Send(createConsumableCommand));
        }

        [HttpPost("categories",Name = "CreateConsumableCategoryAsync")]
        public async Task<ActionResult<Guid>> CreateConsumableCategoryAsync([FromBody] CreateConsumableCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("categories/list", Name = "GetAllConsumableCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ConsumableCategoryListVm>>> GetAllConsumableCategories()
        {
            var dtos = await _mediator.Send(new GetConsumableCategoriesQuery());
            return Ok(dtos);
        }

        [HttpDelete(Name ="DeleteConsumableAsync")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeletConsumableAsync(DeleteConsumableCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpPut(Name ="UpdateConsumableAsync")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> UpdateConsumableAsync(UpdateConsumableCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
