namespace BookingSystem.Application.Features.RoomBookingEvents.Queries.GetRoomBookingEvents
{
    public class ConferenceRoomForChangeEventDto
    {
        public Guid ConferenceRoomId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}