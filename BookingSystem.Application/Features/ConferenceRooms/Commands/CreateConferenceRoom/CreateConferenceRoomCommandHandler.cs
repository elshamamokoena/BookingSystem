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

namespace BookingSystem.Application.Features.ConferenceRooms.Commands.CreateConferenceRoom
{
    public class CreateConferenceRoomCommandHandler : IRequestHandler<CreateConferenceRoomCommand, CreateConferenceRoomCommandResponse>
    {
        private readonly IConferenceRoomRepository _conferenceRoomRepository;
        private readonly IMapper _mapper;
        public CreateConferenceRoomCommandHandler(IConferenceRoomRepository conferenceRoomRepository, IMapper mapper)
        {
            _conferenceRoomRepository = conferenceRoomRepository;
            _mapper = mapper;
        }
        public async Task<CreateConferenceRoomCommandResponse> Handle(CreateConferenceRoomCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateConferenceRoomCommandResponse();
            var validator = new CreateConferenceRoomCommandValidator();

            //validate the request
            var validationResult = await validator.ValidateAsync(request);

            //if validation fails return the errors
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            if (response.Success)
            {
                var conferenceRoom = _mapper.Map<ConferenceRoom>(request);
                conferenceRoom= await _conferenceRoomRepository.AddConferenceRoom(conferenceRoom);
                await _conferenceRoomRepository.SaveChangesAsync();
                response.ConferenceRoom = _mapper.Map<CreateConferenceRoomDto>(conferenceRoom);
                response.Message = "Conference Room Created Successfully.";
            }
            return response;
        }
    }
}
