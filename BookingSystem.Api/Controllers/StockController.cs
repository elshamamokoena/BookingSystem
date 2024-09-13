using BookingSystem.Application.Features.Inventory.Commands.CreateStock;
using BookingSystem.Application.Features.Inventory.Commands.CreateStockItem;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Api.Controllers
{
    [Route("api/stock")]
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
        [HttpPost("stockitems",Name = "CreateStockItemAsync")]
        public async Task<ActionResult<CreateStockItemCommandResponse>> CreateStockItemAsync([FromBody] CreateStockItemCommand createStockItemCommand)
        {
            var response = await _mediator.Send(createStockItemCommand);
            return Ok(response);
        }
    }
}
