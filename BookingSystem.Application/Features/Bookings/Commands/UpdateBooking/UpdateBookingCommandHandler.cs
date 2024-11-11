using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using BookingSystem.ClassLibrary;
using BookingSystem.Domain.Entities.Bookings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Bookings.Commands.UpdateBooking
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, Unit>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        public UpdateBookingCommandHandler(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetEntityAsync(request.BookingId);

            if (booking == null)
                throw new NotFoundException(nameof(Booking), request.BookingId);

            _mapper.Map(request, booking, typeof(UpdateBookingCommand), typeof(Booking));
            _bookingRepository.UpdateEntity(booking);
            await _bookingRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
