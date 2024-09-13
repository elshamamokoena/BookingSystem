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
        private readonly IAmenityRepository _amenityRepository;
        private readonly IMapper _mapper;

        public CreateAmenityCategoryCommandHandler(IAmenityRepository amenityRepository, 
            IMapper mapper)
        {
            _amenityRepository = amenityRepository;
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
            amenityCategory= await _amenityRepository.AddMenityCategory(amenityCategory);
            await _amenityRepository.SaveChangesAsync();
            response.AmenityCategory = _mapper.Map<AmenityCategoryDto>(amenityCategory);
            response.Message = "Amenity Category Created Successfully";
            return response;
        }
    }
}
