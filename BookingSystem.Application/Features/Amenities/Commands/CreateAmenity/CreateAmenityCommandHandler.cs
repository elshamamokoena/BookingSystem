using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using BookingSystem.Domain.Entities.Amenities;
using BookingSystem.Domain.Entities.ConferenceRooms;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Amenities.Commands.CreateAmenity
{
    public class CreateAmenityCommandHandler : IRequestHandler<CreateAmenityCommand, Guid>
    {
        private readonly IAmenityRepository _amenityRepository;
        private readonly IAsyncRepository<AmenityCategory> _amenityCategoryRepository;
        private readonly IConferenceRoomRepository _conferenceRoomRepository;

        private readonly IMapper _mapper;
        public CreateAmenityCommandHandler(IAmenityRepository amenityRepository, IConferenceRoomRepository conferenceRoomRepository,
            IAsyncRepository<AmenityCategory> amenityCategoryRepository, IMapper mapper)
        {
            _amenityRepository = amenityRepository;
            _amenityCategoryRepository = amenityCategoryRepository;
            _mapper = mapper;
            _conferenceRoomRepository = conferenceRoomRepository;
        }
        public async Task<Guid> Handle(CreateAmenityCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAmenityCommandValidator();
            var validationResult = await validator.ValidateAsync(request, new CancellationToken());

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var category = await _amenityCategoryRepository.GetEntityAsync(request.AmenityCategoryId);
            if(category==null)
                throw new NotFoundException("Amenity Category", request.AmenityCategoryId);

            var amenity = _mapper.Map<Amenity>(request);
            amenity= await _amenityRepository.AddAsync(amenity);

            if (amenity.ConferenceRoomId.HasValue)
            {
                var conferenceRoom = await _conferenceRoomRepository.GetEntityAsync(amenity.ConferenceRoomId.Value);
                conferenceRoom.Tags += $"{amenity.Name},{category.Name},";
            }

            await _amenityRepository.SaveChangesAsync();

            return amenity.AmenityId;
        }
    }
}
