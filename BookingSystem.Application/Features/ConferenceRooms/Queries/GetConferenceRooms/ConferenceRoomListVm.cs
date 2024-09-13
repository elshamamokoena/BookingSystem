using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRooms
{
    public class ConferenceRoomListVm
    {
        public IEnumerable< ForListConferenceRoomdto> ConferenceRooms { get; set; }
        public ConferenceRoomListVm(IEnumerable<ForListConferenceRoomdto> conferenceRooms) 
        {
            ConferenceRooms = conferenceRooms;
        }
    }
}
