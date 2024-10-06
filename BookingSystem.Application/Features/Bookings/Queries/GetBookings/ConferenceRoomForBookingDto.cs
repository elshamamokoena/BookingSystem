namespace BookingSystem.Application.Features.Bookings.Queries.GetBookings
{
    public class ConferenceRoomForBookingDto
    {
        public Guid ConferenceRoomId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; } = true;

    }
}