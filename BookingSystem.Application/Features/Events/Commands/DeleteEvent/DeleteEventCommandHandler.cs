using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using BookingSystem.Domain.Entities.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand,Unit>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        public DeleteEventCommandHandler(IAsyncRepository<Event> eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {

            if(!await _eventRepository.EntityExistsAsync(request.EventId))
                throw new NotFoundException(nameof(Event), request.EventId);
            var eventToDelete = await _eventRepository.GetEntityAsync(request.EventId);
            _eventRepository.DeleteEntity(eventToDelete);
            await _eventRepository.SaveChangesAsync();
            return Unit.Value;
        }

   
    }
}
