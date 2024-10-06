using BookingSystem.Application.Features.StockEnquiry.Commands.CreateStockEnquiry;
using BookingSystem.Application.Features.StockEnquiry.Commands.CreateStockItemEnquiry;
using BookingSystem.Application.Features.StockEnquiry.Commands.UpdateStockItemEnquiry;
using BookingSystem.Application.Features.StockEnquiry.Queries.GetStockEnquiries;
using BookingSystem.Application.Features.StockEnquiry.Queries.GetStockEnquiry;
using BookingSystem.Application.Features.StockEnquiry.Queries.GetStockItemEnquiries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Api.Controllers
{
    [Route("api/stockenquiries")]
    [ApiController]
    public class StockEnquiryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StockEnquiryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateStockEnquiryAsync")]
        public async Task<ActionResult<Guid>>
            CreateStockEnquiryAsync([FromBody] CreateStockEnquiryCommand createStockEnquiryCommand)
        {
            return Ok(await _mediator.Send(createStockEnquiryCommand));
        }
        [HttpPost("stockitemenquiries",Name = "CreateStockItemEnquiryAsync")]
        public async Task<ActionResult<Guid>>
            CreateStockItemEnquiryAsync([FromBody] CreateStockItemEnquiryCommand createStockEnquiryCommand)
        {
            return Ok(await _mediator.Send(createStockEnquiryCommand));
        }

        [HttpGet("stockitemenquiries", Name ="GetStockItemEnquiriesAsync")]
        public async Task<ActionResult<StockItemEnquiryListVm>>
            GetStockItemEnquiriesAsync([FromQuery] GetStockItemEnquiriesQuery query)
        {
            return Ok(await _mediator.Send(query));
        }


        [HttpPut("stockitemenquiries", Name = "UpdateStockItemEnquiryAsync")]
        public async Task<ActionResult<UpdateStockItemEnquiryCommandResponse>>
            UpdateStockItemEnquiryAsync(Guid stockItemEnquiryId, [FromBody] UpdateStockItemEnquiryCommand createStockEnquiryCommand)
        {
            return Ok(await _mediator.Send(createStockEnquiryCommand));
        }

        [HttpGet("{stockEnquiryId}",Name = "GetStockEnquiryAsync")]
        public async Task<ActionResult<StockEnquiryVm>>
            GetStockEnquiryAsync([FromQuery] GetStockEnquiryQuery query )
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(Name = "GetStockEnquiriesAsync")]
        public async Task<ActionResult<StockEnquiryListVm>> 
            GetStockEnquiriesAsync([FromQuery]GetStockEnquiriesQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
