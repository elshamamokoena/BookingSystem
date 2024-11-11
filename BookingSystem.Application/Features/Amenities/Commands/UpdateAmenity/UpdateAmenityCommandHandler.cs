using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using BookingSystem.Domain.Entities.Amenities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Amenities.Commands.UpdateAmenity
{
    public class UpdateAmenityCommandHandler : IRequestHandler<UpdateAmenityCommand, Unit>
    {
        private readonly IAmenityRepository _amenityRepository;
        private readonly IConferenceRoomRepository _conferenceRoomRepository;
        private readonly IMapper _mapper;
        public UpdateAmenityCommandHandler(IAmenityRepository amenityRepository, IMapper mapper,
            IConferenceRoomRepository conferenceRoomRepository)
        {
            _amenityRepository = amenityRepository;
            _mapper = mapper;
            _conferenceRoomRepository = conferenceRoomRepository;
        }
        public async Task<Unit> Handle(UpdateAmenityCommand request, CancellationToken cancellationToken)
        {
            if (!await _conferenceRoomRepository.EntityExistsAsync(request.ConferenceRoomId))
                throw new NotFoundException("Conference Room", request.ConferenceRoomId);

            var amenityToUpdate = await _amenityRepository.GetEntityAsync(request.AmenityId);
            if (amenityToUpdate == null)
                throw new NotFoundException("Amenity", request.AmenityId);

            var validator = new UpdateAmenityCommandValidator();
            var validationResult = await validator.ValidateAsync(request, new CancellationToken());
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, amenityToUpdate, typeof(UpdateAmenityCommand), typeof(Amenity));
            _amenityRepository.UpdateEntity(amenityToUpdate);
            await _amenityRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
