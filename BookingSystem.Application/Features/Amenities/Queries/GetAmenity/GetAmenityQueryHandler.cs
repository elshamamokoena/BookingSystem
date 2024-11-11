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

namespace BookingSystem.Application.Features.Amenities.Queries.GetAmenity
{
    public class GetAmenityQueryHandler : IRequestHandler<GetAmenityQuery, AmenityVm>
    {
        private readonly IAmenityRepository _amenityRepository;
        private readonly IMapper _mapper;

        public GetAmenityQueryHandler(IAmenityRepository amenityRepository, IMapper mapper)
        {
            _amenityRepository = amenityRepository;
            _mapper = mapper;
        }
        public async Task<AmenityVm> Handle(GetAmenityQuery request, CancellationToken cancellationToken)
        {

            var amenity = await _amenityRepository.GetAmenityAsync(request);

            if (amenity == null)
                throw new NotFoundException(nameof(Amenity), request.AmenityId);

            return _mapper.Map<AmenityVm>(amenity);
        }
    }
}
