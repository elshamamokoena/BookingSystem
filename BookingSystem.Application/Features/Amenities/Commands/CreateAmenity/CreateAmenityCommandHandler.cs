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

namespace BookingSystem.Application.Features.Amenities.Commands.CreateAmenity
{
    public class CreateAmenityCommandHandler : IRequestHandler<CreateAmenityCommand, CreateAmenityCommandResponse>
    {
        private readonly IAmenityRepository _amenityRepository;
        private readonly IMapper _mapper;
        public CreateAmenityCommandHandler(IAmenityRepository amenityRepository, IMapper mapper)
        {
            _amenityRepository = amenityRepository;
            _mapper = mapper;
        }
        public async Task<CreateAmenityCommandResponse> Handle(CreateAmenityCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateAmenityCommandResponse();
            var validator = new CreateAmenityCommandValidator();
            var validationResult = await validator.ValidateAsync(request, new CancellationToken());

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            if(!await _amenityRepository.AmenityCategoryExists(request.AmenityCategoryId))
                throw new NotFoundException("Amenity Category", request.AmenityCategoryId);

            var amenity = _mapper.Map<Amenity>(request);
            amenity= await _amenityRepository.AddAmenity(amenity);
            await _amenityRepository.SaveChangesAsync();
            response.Amenity = _mapper.Map<AmenityDto>(amenity);
            response.Amenity.AmenityCategoryName = (await _amenityRepository.GetAmenityCategoryAsync(request.AmenityCategoryId)).Name;
            response.Message = "Amenity Created Successfully";
            return response;
        }
    }
}
