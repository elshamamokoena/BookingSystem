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

namespace BookingSystem.Application.Features.Amenities.Commands.CreateAmenityCategory
{
    public class CreateAmenityCategoryCommandHandler : IRequestHandler<CreateAmenityCategoryCommand, CreateAmenityCategoryCommandResponse>
    {
        private readonly IAsyncRepository<AmenityCategory> _amenityCategoryRepository;
        private readonly IMapper _mapper;

        public CreateAmenityCategoryCommandHandler(IAsyncRepository<AmenityCategory> amenityCategoryRepository, 
            IMapper mapper)
        {
            _amenityCategoryRepository = amenityCategoryRepository;
            _mapper = mapper;
        }
        public async Task<CreateAmenityCategoryCommandResponse> Handle(CreateAmenityCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateAmenityCategoryCommandResponse();
            var validator = new CreateAmenityCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if(validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult);

            var amenityCategory = _mapper.Map<AmenityCategory>(request);
            amenityCategory= await _amenityCategoryRepository.AddAsync(amenityCategory);
            await _amenityCategoryRepository.SaveChangesAsync();
            response.AmenityCategory = _mapper.Map<AmenityCategoryDto>(amenityCategory);
            response.Message = "Amenity Category Created Successfully";
            return response;
        }
    }
}
