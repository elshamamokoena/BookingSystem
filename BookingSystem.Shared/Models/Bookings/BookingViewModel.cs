using BookingSystem.Shared.Models.Events;
using BookingSystem.Shared.Models.Rooms;
using BookingSystem.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Models.Bookings
{
    public partial class BookingViewModel
    {
        public Guid BookingId { get; set; }
        public Guid EventId { get; set; }
        public EventForBookingDto? Event { get; set; }
        public Guid ConferenceRoomId { get; set; }
        public ConferenceRoomForBookingDto? ConferenceRoom { get; set; }
        public string Status { get; set; } = string.Empty;
    }
    public partial class BookingViewModel
    {
        //extended properties
        public Badge? Badge { get; set; }
        public string ElementId => $"booking-dropdown-{BookingId}";

    }

}
