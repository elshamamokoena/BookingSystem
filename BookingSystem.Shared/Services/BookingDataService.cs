using AutoMapper;
using Blazored.LocalStorage;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Models.Bookings;
using BookingSystem.Shared.Services.Base;
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
                ILocalStorageService localStorageService) : base(client, localStorageService)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookingViewModel>> GetBookingsAsync(Guid eventId, int? pageNumber, int? pageSize)
        {
            var bookings = await _client.GetBookingsAsync(eventId, pageNumber,pageSize);

            return _mapper.Map<IEnumerable<BookingViewModel>>(bookings);
        }
    }
}
