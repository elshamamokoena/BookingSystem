using BookingSystem.Application.Features.Events.Commands.CreateEvent;
using BookingSystem.Application.Features.Events.Commands.DeleteEvent;
using BookingSystem.Application.Features.Events.Commands.UpdateEvent;
using BookingSystem.Application.Features.Events.Queries.GetEvent;
using BookingSystem.Application.Features.Events.Queries.GetEvents;
using BookingSystem.Application.ResourceParameters;
using BookingSystem.AuthorizationPolicies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/events")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class EventController:ControllerBase
    {
        private readonly IMediator _mediator;
        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost(Name ="CreateEventAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> CreateEventAsync([FromBody] CreateEventCommand createBookingCommand)
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
        //[Authorize(Policy = Policies.IsManager)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<EventVm>> GetEventAsync(Guid eventId)
        {
            return Ok(await _mediator.Send(new GetEventQuery { EventId = eventId }));
        }

        [HttpGet(Name = "GetEventsAsync")]
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
