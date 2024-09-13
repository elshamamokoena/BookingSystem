using AutoMapper;
using Blazored.LocalStorage;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Models.Booking;
using BookingSystem.Shared.Services;
using BookingSystem.Shared.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Web.App.Services
{
    public class BookingDataService :DataServiceBase, IBookingDataService
    {
        private readonly IMapper _mapper;
        public BookingDataService(IClient client, IMapper mapper,
            ILocalStorageService localStorageService) : base(client, localStorageService)
        {
            _mapper = mapper;
        }

        public async Task<BookingViewModel> GetBooking(Guid bookingId)
        {
       
                return _mapper.Map<BookingViewModel>(await _client.GetBookingAsync(bookingId: bookingId, includeRooms: false));
        }
    }
}
