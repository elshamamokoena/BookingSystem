using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using BookingSystem.Domain.Entities.ConferenceRooms;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.ConferenceRooms.Commands.UpdateConferenceRoom.UpdateConferenceRoom
{
    
    public class UpdateConferenceRoomCommandHandler : IRequestHandler<UpdateConferenceRoomCommand,Unit>
    {
        private readonly IConferenceRoomRepository _conferenceRoomRepository;
        private readonly IMapper _mapper;

        public UpdateConferenceRoomCommandHandler(IMapper mapper, 
            IConferenceRoomRepository conferenceRoomRepository)
        {
            _mapper = mapper;
            _conferenceRoomRepository = conferenceRoomRepository;
        }
        public async Task<Unit> Handle(UpdateConferenceRoomCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateConferenceRoomCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            if(!await _conferenceRoomRepository.EntityExistsAsync(request.ConferenceRoomId))
                throw new NotFoundException(nameof(ConferenceRoom), request.ConferenceRoomId);

            var room = await _conferenceRoomRepository.GetEntityAsync(request.ConferenceRoomId);
            _mapper.Map(request, room);
            _conferenceRoomRepository.UpdateEntity(room);
            await _conferenceRoomRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
