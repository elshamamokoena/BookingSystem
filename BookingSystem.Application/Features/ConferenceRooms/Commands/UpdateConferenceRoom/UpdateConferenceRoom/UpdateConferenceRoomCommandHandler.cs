﻿using AutoMapper;
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
    
    public class UpdateConferenceRoomCommandHandler : IRequestHandler<UpdateConferenceRoomCommand, UpdateConferenceRoomCommandResponse>
    {
        private readonly IConferenceRoomRepository _conferenceRoomRepository;
        private readonly IMapper _mapper;

        public UpdateConferenceRoomCommandHandler(IMapper mapper, 
            IConferenceRoomRepository conferenceRoomRepository)
        {
            _mapper = mapper;
            _conferenceRoomRepository = conferenceRoomRepository;
        }
        public async Task<UpdateConferenceRoomCommandResponse> Handle(UpdateConferenceRoomCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateConferenceRoomCommandResponse();
            var validator = new UpdateConferenceRoomCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            if(!await _conferenceRoomRepository.ConferenceRoomExistsAsync(request.ConferenceRoomId))
                throw new NotFoundException(nameof(ConferenceRoom), request.ConferenceRoomId);

            var room = await _conferenceRoomRepository.GetConferenceRoomAsync(request.ConferenceRoomId);
            _mapper.Map(request, room);
            _conferenceRoomRepository.UpdateConferenceRoom(room);
            await _conferenceRoomRepository.SaveChangesAsync();
            response.ConferenceRoom = _mapper.Map<UpdatedConferenceRoomDto>(room);
            response.Message = "Conference Room Updated Successfully";
            return response;
        }
    }
}
