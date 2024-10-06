using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using BookingSystem.Domain.Entities.ConferenceRooms;
using BookingSystem.Domain.Entities.Events;
using FluentValidation;
using MediatR;

namespace BookingSystem.Application.Features.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommandValidator:AbstractValidator<CreateBookingCommand>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IAsyncRepository<ConferenceRoom> _conferenceRoomRepository;

        public CreateBookingCommandValidator(IBookingRepository bookingRepository,
            IAsyncRepository<Event> eventRepository,
            IAsyncRepository<ConferenceRoom> conferenceRoomRepository)
        {

            _bookingRepository = bookingRepository;
            _conferenceRoomRepository = conferenceRoomRepository;
            _eventRepository = eventRepository;

            RuleFor(p => p.EventId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .NotEqual(Guid.Empty).WithMessage("{PropertyName} is required.");

            RuleFor(p => p.ConferenceRoomId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .NotEqual(Guid.Empty).WithMessage("{PropertyName} is required.");
            RuleFor(e=>e)
                 .MustAsync(IsBookingConflict)
                 .WithMessage("The room is already booked for the selected date and time.");
        }

        private async Task<bool> IsBookingConflict(CreateBookingCommand request, CancellationToken token)
        {
            var @event = await _eventRepository.GetEntityAsync(request.EventId);

            if (@event == null)
                throw new NotFoundException(nameof(Event), request.EventId);

            if(!await _conferenceRoomRepository.EntityExistsAsync(request.ConferenceRoomId))
                throw new NotFoundException(nameof(ConferenceRoom), request.ConferenceRoomId);

            return !(await _bookingRepository.IsBookingConflict(@event.Start, @event.End, request.ConferenceRoomId ));
        }
    }
}