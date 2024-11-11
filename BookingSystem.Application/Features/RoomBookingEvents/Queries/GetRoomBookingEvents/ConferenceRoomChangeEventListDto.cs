using BookingSystem.Application.Features.Amenities.Queries.GetAmenity;
using BookingSystem.Domain.Entities.ConferenceRooms;

namespace BookingSystem.Application.Features.RoomBookingEvents.Queries.GetRoomBookingEvents
{
    public class ConferenceRoomChangeEventListDto
    {
        public Guid ConferenceRoomChangeEventId { get; set; }
        public Guid ConferenceRoomId { get; set; }
        public ConferenceRoomForChangeEventDto ? ConferenceRoom { get; set; }
        public string ChangeType { get; set; } = string.Empty;
        public int Amount { get; set; }
    }
}