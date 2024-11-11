using BookingSystem.Application.Features.Inventory.Commands.CreateStock;
using BookingSystem.Application.Features.Inventory.Commands.CreateStockItem;
using BookingSystem.Application.Features.Inventory.Commands.DeleteStockItem;
using BookingSystem.Application.Features.Inventory.Commands.UpdateStockItem;
using BookingSystem.Application.Features.Inventory.Queries.GetStockItem;
using BookingSystem.Application.Features.Inventory.Queries.GetStockItemForConsumable;
using BookingSystem.Application.Features.Inventory.Queries.GetStockItems;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Api.Controllers
{
    [Route("api/consumables/stockitems")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StockController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost(Name ="CreateStockAsync")]
        public async Task<ActionResult<CreateStockCommandResponse>> CreateStockAsync([FromBody] CreateStockCommand createStockCommand)
        {
            var response = await _mediator.Send(createStockCommand);
            return Ok(response);
        }

        [HttpGet("detail", Name = "GetStockItemAsync")]
        public async Task<ActionResult<StockItemVm>> GetStockItemAsync([FromQuery] GetStockItemQuery getStockItemQuery)
        {
            var item = await _mediator.Send(getStockItemQuery);
            return Ok(item);
        }
        [HttpGet("detail/consumable", Name = "GetStockItemByConsumableAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StockItemVm>> GetStockItemByConsumableAsync(Guid consumableId)
        {
            var item = await _mediator.Send(new GetStockItemForConsumableQuery { ConsumableId=consumableId});
            return Ok(item);
        }



        [HttpGet("list", Name ="GetStockItemsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<StockItemListVm>> GetStockItemsAsync([FromQuery] GetStockItemsQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPost("stockitems",Name = "CreateStockItemAsync")]
        public async Task<ActionResult<Guid>> CreateStockItemAsync([FromBody] CreateStockItemCommand createStockItemCommand)
        {
            var response = await _mediator.Send(createStockItemCommand);
            return Ok(response);
        }

        [HttpDelete("{stockItemId}", Name = "DeleteStockItemAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteStockItemAsync(Guid stockItemId)
        {
            await _mediator.Send(new DeleteStockItemCommand { StockItemId = stockItemId });
            return NoContent();
        }

        [HttpPut(Name = "UpdateStockItemAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateStockItemAsync([FromBody] UpdateStockItemCommand updateStockItemCommand)
        {
            await _mediator.Send(updateStockItemCommand);
            return NoContent();
        }
    }
}
