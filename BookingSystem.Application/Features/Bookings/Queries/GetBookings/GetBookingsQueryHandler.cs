using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using BookingSystem.Domain.Entities.Bookings;
using BookingSystem.Domain.Entities.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Bookings.Queries.GetBookings
{
    class GetBookingsQueryHandler : IRequestHandler<GetBookingsQuery, IEnumerable<BookingVm>>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IAsyncRepository<Event> _asyncRepository; 
        private readonly IMapper _mapper;
        public GetBookingsQueryHandler(IBookingRepository bookingRepository,
            IAsyncRepository<Event> repository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _asyncRepository = repository;
            _mapper = mapper;

        }
        public async Task<IEnumerable<BookingVm>> Handle(GetBookingsQuery request, CancellationToken cancellationToken)
        {
            if(!await _asyncRepository.EntityExistsAsync(request.EventId))
                throw new NotFoundException("Event", request.EventId);
            var bookings = await _bookingRepository.GetBookingsAsync(request);
            return _mapper.Map<IEnumerable<BookingVm>>(bookings);
        }
    }
}
