using BookingSystem.Shared.Models.Rooms;
using BookingSystem.Shared.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Contracts
{
    public interface IConferenceRoomService
    {
        Task<ConferenceRoomListViewModel> GetConferenceRoomsAsync(string ? searchQuery, DateTime? start, DateTime? end, int ? pageNumber, int? pageSize  );
        Task<ApiResponse<Guid>> CreateConferenceRoomAsync(RoomViewModel room);
        Task<RoomViewModel> GetConferenceRoomAsync(Guid roomId, bool? includeBookings, bool? includeAmenities);
        Task<ApiResponse<Guid>> UpdateConferenceRoomAsync(RoomViewModel room);

        Task<ApiResponse<Guid>> DeleteConferenceRoomAsync(Guid roomId);

    
    }
}
