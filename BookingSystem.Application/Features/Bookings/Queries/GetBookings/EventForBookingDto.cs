using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Bookings.Queries.GetBookings
{
    public class EventForBookingDto
    {
        public Guid EventId { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
        //public string Label { get; set; } = string.Empty;
    }
}
