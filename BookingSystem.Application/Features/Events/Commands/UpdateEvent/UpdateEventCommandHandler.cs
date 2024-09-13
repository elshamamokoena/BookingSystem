using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using BookingSystem.Application.Features.Events.Queries.GetEvent;
using BookingSystem.Domain.Entities.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, UpdateEventCommandResponse>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IConferenceRoomRepository _conferenceRoomRepository;
        private readonly IMapper _mapper;
        public UpdateEventCommandHandler(IAsyncRepository<Event> eventRepository,
            IConferenceRoomRepository conferenceRoomRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _conferenceRoomRepository = conferenceRoomRepository;
            _mapper = mapper;
        }
        public async Task<UpdateEventCommandResponse> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateEventCommandResponse();
            var validator = new UpdateEventCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            if (!await _eventRepository.EntityExistsAsync(request.EventId))
                throw new NotFoundException("Event", request.EventId);

            var eventToUpdate = await _eventRepository.GetEntityAsync(request.EventId);

            _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));

            _eventRepository.UpdateEntity(eventToUpdate);

            if (!await _eventRepository.SaveChangesAsync())
            {
                response.Success = false;
                response.Message = "There was an issue updating the event. Please try again later.";
            }
            else
                response.Event = _mapper.Map<EventVm>(eventToUpdate);

            return response;
        }
    }

}
