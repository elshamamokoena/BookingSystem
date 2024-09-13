using BookingSystem.Application.Features.ConferenceRooms.Commands.CreateConferenceRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Bookings.Queries.GetBookings
{
    public class BookingVm
    {
        public Guid BookingId { get; set; }
        public Guid EventId { get; set; }
        public EventForBookingDto Event { get; set; } = default!;
        public Guid ConferenceRoomId { get; set; }
        public ConferenceRoomForBookingDto ConferenceRoom { get; set; } = default!;
        public string Status { get; set; } = string.Empty;
    }
}
