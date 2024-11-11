using BookingSystem.Application.ResourceParameters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Bookings.Queries.GetBookings
{
    public class GetBookingsQuery :ResourceParameterBase, IRequest<IEnumerable<BookingVm>>
    {
        public Guid ? EventId { get; set; }

    }
}
