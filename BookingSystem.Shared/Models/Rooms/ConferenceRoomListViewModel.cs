using BookingSystem.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Models.Rooms
{
    public class ConferenceRoomListViewModel
    {
        public int Count { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public ICollection<RoomViewModel>? ConferenceRooms { get; set; }
    }
}
