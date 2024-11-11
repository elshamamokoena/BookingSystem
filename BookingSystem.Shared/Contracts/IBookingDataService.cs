using BookingSystem.Shared.Components.Pages.Bookings;
using BookingSystem.Shared.Components.Pages.Events.EditEvents;
using BookingSystem.Shared.Models.Bookings;
using BookingSystem.Shared.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Contracts
{
    public interface IBookingDataService
    {
        Task<IEnumerable<BookingViewModel>> GetBookingsAsync(Guid? eventId, int ? pageNumber, int? pageSize);
        Task<ApiResponse<Guid>> CreateBookingAsync(AddBookingViewModel booking);
        Task<BookingViewModel> GetBookingAsync(Guid bookingId, bool ? includeEvent, bool ? includeRoom);
        Task<ApiResponse<Guid>> UpdateBookingAsync(UpdateBookingViewModel booking);
    }
}
