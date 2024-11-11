using BookingSystem.Application.Features.RoomBookingEvents.Queries.GetRoomBookingEvents;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Api.Controllers
{
    [Route("api/analytics")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AnalyticsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetConferenceRoomChangeEventsAsync")]
        public async Task<ActionResult<ConferenceRoomChangeEventListVm>> GetConferenceRoomChangeEventsAsync([FromQuery] GetConferenceRoomChangeEventsQuery query)
        {
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }
    }
}
