using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Bookings.Commands.UpdateBooking
{
    public class UpdateBookingCommand:IRequest<Unit>
    {
        public Guid BookingId { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
