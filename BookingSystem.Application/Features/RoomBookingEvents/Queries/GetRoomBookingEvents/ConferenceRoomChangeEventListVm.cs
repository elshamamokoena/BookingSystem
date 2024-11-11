using BookingSystem.Application.Models;

namespace BookingSystem.Application.Features.RoomBookingEvents.Queries.GetRoomBookingEvents
{
    public class ConferenceRoomChangeEventListVm:PagedVm
    {
        public IEnumerable<ConferenceRoomChangeEventListDto>? ConferenceRoomChangeEvents { get; set; }
    }
}