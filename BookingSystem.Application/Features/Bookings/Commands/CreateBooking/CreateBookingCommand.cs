using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommand:IRequest<Guid>
    {
        public Guid EventId { get; set; }
        public Guid ConferenceRoomId { get; set; }

    }
}
