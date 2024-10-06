using AutoMapper;
using Blazored.LocalStorage;
using BookingSystem.Shared.Components.Pages.Events.EditEvents;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Models.Bookings;
using BookingSystem.Shared.Services.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Services
{
    public class BookingDataService :DataServiceBase, IBookingDataService
    {
        private readonly IMapper _mapper;
        public BookingDataService(IMapper mapper,IClient client,
                ILocalStorageService localStorageService ,
                NavigationManager navigationManager) : base(client, localStorageService, navigationManager)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> CreateBookingAsync(AddBookingViewModel booking)
        {
            try
            {

                var newId = await _client.CreateBookingAsync(new CreateBookingCommand 
                         { ConferenceRoomId = booking.ConferenceRoomId, EventId = booking.EventId });

                return new ApiResponse<Guid>() { Data = newId, IsSuccess = true };
            }
            catch(ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }

        }

        public async Task<BookingViewModel> GetBookingAsync(Guid bookingId, bool? includeEvent, bool? includeRoom)
        {
            var booking = await _client.GetBookingAsync(bookingId, includeEvent, includeRoom);
            return _mapper.Map<BookingViewModel>(booking);
        }

        public async Task<IEnumerable<BookingViewModel>> GetBookingsAsync(Guid eventId, int? pageNumber, int? pageSize)
        {
            var bookings = await _client.GetBookingsAsync(eventId, pageNumber,pageSize);
            return _mapper.Map<IEnumerable<BookingViewModel>>(bookings.ToList());
        }

    
    }
}
