using BookingSystem.Application.Features.Events.Commands.CreateEvent;
using BookingSystem.Application.Features.Events.Commands.DeleteEvent;
using BookingSystem.Application.Features.Events.Commands.UpdateEvent;
using BookingSystem.Application.Features.Events.Queries.GetEvent;
using BookingSystem.Application.Features.Events.Queries.GetEvents;
using BookingSystem.Application.ResourceParameters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventController:ControllerBase
    {
        private readonly IMediator _mediator;
        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name ="CreateEventAsync")]
        public async Task<ActionResult<CreateEventCommandResponse>> CreateEventAsync([FromBody] CreateEventCommand createBookingCommand)
        {
            return Ok(await _mediator.Send(createBookingCommand));
        }

        [HttpPut(Name = "UpdateEventAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UpdateEventCommandResponse>> UpdateEventAsync([FromBody] UpdateEventCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{eventId}", Name = "GetEventAsync")]
        public async Task<ActionResult<EventVm>> GetEventAsync(Guid eventId)
        {
            return Ok(await _mediator.Send(new GetEventQuery { EventId = eventId }));
        }

        [HttpGet(Name = "GetEventsAsync")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EventVm>>> GetBookingsAsync([FromQuery] GetEventsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpDelete("{eventId}", Name = "DeleteEventAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid eventId)
        {
            var deleteEventCommand = new DeleteEventCommand() { EventId = eventId };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }
    }
}
