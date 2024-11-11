using BookingSystem.Application.ResourceParameters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.RoomBookingEvents.Queries.GetRoomBookingEvents
{
    public class GetConferenceRoomChangeEventsQuery:ResourceParameterBase,IRequest<ConferenceRoomChangeEventListVm>
    {
        public Guid? ConferenceRoomId { get; set; }
        public string? ChangeEventType { get; set; }
        public bool? IncludeConferenceRoom { get; set; }
    }
}
