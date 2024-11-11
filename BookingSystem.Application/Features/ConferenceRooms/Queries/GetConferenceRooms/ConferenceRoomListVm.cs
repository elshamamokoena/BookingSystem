using BookingSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRooms
{
    public class ConferenceRoomListVm:PagedVm
    {
        public IEnumerable<ConferenceRoomListDto>? ConferenceRooms { get; set; }
    }
}
