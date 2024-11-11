using BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRoom;
using BookingSystem.Application.Helpers;
using BookingSystem.Application.ResourceParameters;
using BookingSystem.ClassLibrary;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRooms
{
    public class GetConferenceRoomsQuery:ResourceParameterBase,IRequest<ConferenceRoomListVm>
    {
        public string? SearchQuery { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }


    }
}
