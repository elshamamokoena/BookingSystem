using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Amenities.Commands.AddAmenityToRoom
{
    public class AddAmenityToRoomCommandHandler : IRequestHandler<AddAmenityToRoomCommand, AddAmenityToRoomCommandResponse>
    {
        private readonly IAmenityRepository _amenityRepository;
        private readonly IConferenceRoomRepository _conferenceRoomRepository;
        private readonly IMapper _mapper;
        public AddAmenityToRoomCommandHandler(IAmenityRepository amenityRepository, IMapper mapper,
            IConferenceRoomRepository conferenceRoomRepository)
        {
            _amenityRepository = amenityRepository;
            _mapper = mapper;
            _conferenceRoomRepository = conferenceRoomRepository;
        }
        public async Task<AddAmenityToRoomCommandResponse> Handle(AddAmenityToRoomCommand request, CancellationToken cancellationToken)
        {
            var response = new AddAmenityToRoomCommandResponse();
            var validator = new AddAmenityToRoomCommandValidator();
            var validationResult = await validator.ValidateAsync(request, new CancellationToken());
            if(validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            if (!await _conferenceRoomRepository.EntityExistsAsync(request.RoomId)) 
                throw new NotFoundException("Conference Room", request.RoomId);

            if (!await _amenityRepository.AmenityExistsAsync(request.AmenityId))
                throw new NotFoundException("Amenity", request.AmenityId);

            var amenity = await _amenityRepository.GetAmenityAsync(request.AmenityId);

            amenity.ConferenceRoomId = request.RoomId;
            _amenityRepository.UpdateAmenity(amenity);
            await _amenityRepository.SaveChangesAsync();
            response.Amenity = _mapper.Map<AmenityWithRoomDto>(amenity);
            response.Message = "Amenity added to room successfully";
            return response;
        }
    }
}
