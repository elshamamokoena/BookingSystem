using BookingSystem.Shared.Models.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Contracts
{
    public interface IBookingDataService
    {
        Task<IEnumerable<BookingViewModel>> GetBookingsAsync(Guid eventId, int ? pageNumber, int? pageSize);
    }
}
