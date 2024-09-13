using BookingSystem.Application.Features.Bookings.Queries.GetBookings;
using BookingSystem.Domain.Entities.Bookings;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Api.Controllers
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name ="GetBookingsAsync")]
        public async Task<ActionResult<IEnumerable<BookingVm>>> GetBookings([FromQuery] GetBookingsQuery query)
        {
            var bookings = await _mediator.Send(query);
            return Ok(bookings);
        }
    }
}
