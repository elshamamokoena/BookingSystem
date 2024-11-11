using BookingSystem.Application.Features.Bookings.Commands.CreateBooking;
using BookingSystem.Application.Features.Bookings.Commands.UpdateBooking;
using BookingSystem.Application.Features.Bookings.Queries.GetBooking;
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

        [HttpGet("/booking-detail", Name = "GetBookingAsync")]
        public async Task<ActionResult<BookingVm>> GetBooking([FromQuery]GetBookingQuery query)
        {
            var booking = await _mediator.Send(query);
            return Ok(booking);
        }
        [HttpPost(Name ="CreateBookingAsync")]
        public async Task<ActionResult<Guid>>  CreateBooking([FromBody] CreateBookingCommand command)
        {
            var bookingId = await _mediator.Send(command);
            return Ok(bookingId);
        }

        [HttpPut(Name = "UpdateBookingAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateBookingAsync([FromBody] UpdateBookingCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
