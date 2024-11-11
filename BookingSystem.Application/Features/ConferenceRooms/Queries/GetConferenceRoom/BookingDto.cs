using BookingSystem.Application.Features.Bookings.Queries.GetBookings;

namespace BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRoom
{
    public class BookingDto
    {
        public Guid BookingId { get; set; }
        public int BookingNumber { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public Guid EventId { get; set; }
        public EventForBookingDto Event { get; set; } = default!;
    }
}