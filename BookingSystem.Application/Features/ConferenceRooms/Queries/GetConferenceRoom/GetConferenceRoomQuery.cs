using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRoom
{
    public class GetConferenceRoomQuery:IRequest<ConferenceRoomVm>
    {
        public Guid ConferenceRoomId { get; set; }
        public GetConferenceRoomQuery() { }
        public GetConferenceRoomQuery(Guid conferenceRoomId)
        {
            ConferenceRoomId = conferenceRoomId;
        }

    }
}
