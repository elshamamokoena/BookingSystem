using BookingSystem.Application.Features.ConferenceRooms.Commands.CreateConferenceRoom;
using BookingSystem.Application.Features.ConferenceRooms.Commands.DeleteConferenceRoom;
using BookingSystem.Application.Features.ConferenceRooms.Commands.UpdateConferenceRoom.UpdateConferenceRoom;
using BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRoom;
using BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRooms;
using BookingSystem.Application.ResourceParameters;
using MediatR;
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
        public async Task<ActionResult<CreateConferenceRoomCommandResponse>> 
            CreateConferenceRoomAsync([FromBody] CreateConferenceRoomCommand createConferenceRoomCommand )
        {
            return Ok(await _mediator.Send(createConferenceRoomCommand));
        }

        [HttpPut(Name ="UpdateConferenceRoomAsync")]
        public async Task<ActionResult<UpdateConferenceRoomCommandResponse>> 
            UpdateConferenceRoomAsync([FromBody] UpdateConferenceRoomCommand updateConferenceRoomCommand)
        {
            return Ok(await _mediator.Send(updateConferenceRoomCommand));
        }


        [HttpGet("{conferenceRoomId}", Name ="GetConferenceRoomAsync")]
        public async Task<ActionResult<ConferenceRoomVm>> GetConferenceRoomAsync(Guid conferenceRoomId)
        {
            var query = new GetConferenceRoomQuery(conferenceRoomId);
            return Ok(await _mediator.Send(query));
        }


        [HttpGet(Name ="GetConferenceRoomsAsync")]
        public async Task<ActionResult<IEnumerable<ConferenceRoomVm>>> 
            GetConferenceRoomsAsync([FromQuery] GetConferenceRoomsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpDelete("{conferenceRoomId}", Name ="DeleteConferenceRoomAsync")]
        public async Task<ActionResult<bool>> DeleteConferenceRoomAsync(Guid conferenceRoomId)
        {
            return Ok(await _mediator.Send(
                new DeleteConferenceRoomCommand{ConferenceRoomId=conferenceRoomId }));
        }
  
    }
}
