using BookingSystem.Shared.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Contracts
{
    public interface IConferenceRoomService
    {
        Task<IEnumerable<RoomViewModel>> GetConferenceRooms(string ? searchQuery, DateTime ? start, DateTime ? end, int ? pageNumber, int? pageSize  );
    }
}
