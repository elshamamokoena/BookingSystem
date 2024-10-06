using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using BookingSystem.Domain.Entities.Bookings;
using BookingSystem.Domain.Entities.ConferenceRooms;
using BookingSystem.Domain.Entities.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Guid>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IAsyncRepository<ConferenceRoom> _conferenceRoomRepository;
        private readonly IMapper _mapper;
        public CreateBookingCommandHandler(IBookingRepository bookingRepository,
            IAsyncRepository<Event> eventRepository, IAsyncRepository<ConferenceRoom> conferenceRoomRepository,
            IMapper mapper )
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
            _eventRepository = eventRepository;
            _conferenceRoomRepository = conferenceRoomRepository;
        }
        public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBookingCommandValidator(_bookingRepository,
                _eventRepository,
                _conferenceRoomRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var booking = _mapper.Map<Booking>(request);
            booking.Status = nameof(BookingStatus.Pending);
            booking = await _bookingRepository.AddAsync(booking);
            await _bookingRepository.SaveChangesAsync();
            return booking.BookingId;
        }
    }
}
