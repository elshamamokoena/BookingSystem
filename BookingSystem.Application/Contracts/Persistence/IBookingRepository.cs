using BookingSystem.Application.Features.Bookings.Queries.GetBooking;
using BookingSystem.Application.Features.Bookings.Queries.GetBookings;
using BookingSystem.Application.Features.Events.Queries.GetEvents;
using BookingSystem.Domain.Entities.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Contracts.Persistence
{
    public interface IBookingRepository: IAsyncRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetBookingsAsync(GetBookingsQuery bookingsQuery);
        Task<Booking> GetBookingAsync(GetBookingQuery query);
        Task<bool> IsBookingConflict(DateTime ? startDate, DateTime ? endDate, Guid conferenceRoomId);
    }
}
