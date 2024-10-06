using BookingSystem.Application.Features.Bookings.Queries.GetBookings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Bookings.Queries.GetBooking
{
    public class GetBookingQuery:IRequest<BookingVm>
    {
        public Guid BookingId { get; set; }
        public bool ? IncludeEvent { get; set; }
        public bool? IncludeRoom { get; set; }
    }
}
