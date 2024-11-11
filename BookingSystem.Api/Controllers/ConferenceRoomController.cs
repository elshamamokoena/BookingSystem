using BookingSystem.Application.Features.ConferenceRooms.Commands.CreateConferenceRoom;
using BookingSystem.Application.Features.ConferenceRooms.Commands.DeleteConferenceRoom;
using BookingSystem.Application.Features.ConferenceRooms.Commands.UpdateConferenceRoom.UpdateConferenceRoom;
using BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRoom;
using BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRooms;
using BookingSystem.Application.Helpers;
using BookingSystem.Application.ResourceParameters;
using BookingSystem.AuthorizationPolicies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/conferencerooms")]
    public class ConferenceRoomController : ControllerBase
    {

        private readonly IMediator _mediator;
        public ConferenceRoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name ="CreateConferenceRoomAsync")]
        [Authorize(Policy =Policies.IsManager)]
        public async Task<ActionResult<Guid>> CreateConferenceRoomAsync([FromBody] CreateConferenceRoomCommand createConferenceRoomCommand )
        {
            return Ok(await _mediator.Send(createConferenceRoomCommand));
        }

        [HttpPut(Name ="UpdateConferenceRoomAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateConferenceRoomAsync([FromBody] UpdateConferenceRoomCommand updateConferenceRoomCommand)
        {
            await _mediator.Send(updateConferenceRoomCommand);
            return NoContent();
        }


        [HttpGet("detail", Name ="GetConferenceRoomAsync")]
        public async Task<ActionResult<ConferenceRoomVm>> GetConferenceRoomAsync([FromQuery]GetConferenceRoomQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(Name ="GetConferenceRoomsAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ConferenceRoomListVm>> GetConferenceRoomsAsync([FromQuery] GetConferenceRoomsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpDelete("{conferenceRoomId}", Name ="DeleteConferenceRoomAsync")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteConferenceRoomAsync(Guid conferenceRoomId)
        {
            await _mediator.Send(new DeleteConferenceRoomCommand{ConferenceRoomId=conferenceRoomId });
            return NoContent();
        }
  
    }
}
