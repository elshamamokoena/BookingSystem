using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using BookingSystem.Application.Models;
using BookingSystem.ClassLibrary;
using BookingSystem.Domain.Entities.ConferenceRooms;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.ConferenceRooms.Commands.CreateConferenceRoom
{
    public class CreateConferenceRoomCommandHandler : IRequestHandler<CreateConferenceRoomCommand, Guid>
    {
        private readonly IConferenceRoomRepository _conferenceRoomRepository;
        private readonly IMapper _mapper;
        public CreateConferenceRoomCommandHandler(IConferenceRoomRepository conferenceRoomRepository, IMapper mapper)
        {
            _conferenceRoomRepository = conferenceRoomRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateConferenceRoomCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateConferenceRoomCommandValidator();
            //validate the request
            var validationResult = await validator.ValidateAsync(request);
            //if validation fails return the errors
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var conferenceRoom = _mapper.Map<ConferenceRoom>(request);
            conferenceRoom.Status = nameof(ConferenceRoomStatus.VacantAndNotBooked);
            conferenceRoom = await _conferenceRoomRepository.AddAsync(conferenceRoom);
            await _conferenceRoomRepository.SaveChangesAsync();
            return conferenceRoom.ConferenceRoomId;
        }
    }
}
