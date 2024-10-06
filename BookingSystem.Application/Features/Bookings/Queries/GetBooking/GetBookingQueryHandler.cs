using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using BookingSystem.Application.Features.Bookings.Queries.GetBookings;
using BookingSystem.Domain.Entities.Bookings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Bookings.Queries.GetBooking
{
    public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, BookingVm>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        public GetBookingQueryHandler(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }
        public async Task<BookingVm> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            if(!await _bookingRepository.EntityExistsAsync(request.BookingId))
                throw new NotFoundException(nameof(Booking), request.BookingId);

            var booking = await _bookingRepository.GetBookingAsync(request);
            return _mapper.Map<BookingVm>(booking);
        }
    }
}
