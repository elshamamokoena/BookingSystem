namespace BookingSystem.Application.Features.Bookings.Queries.GetBookings
{
    public class ConferenceRoomForBookingDto
    {
        public Guid ConferenceRoomId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}