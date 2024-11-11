using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Domain.Entities.Amenities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Amenities.Queries.GetAmenities
{
    public class GetAmenitiesQueryHandler : IRequestHandler<GetAmenitiesQuery, IEnumerable<AmenityListVm>>
    {
        private readonly IAmenityRepository _amenityRepository;
        private readonly IMapper _mapper;
        
        public GetAmenitiesQueryHandler(IMapper mapper, IAmenityRepository amenityRepository)
        {
            _mapper = mapper;
            _amenityRepository = amenityRepository;
        }
        public async Task<IEnumerable<AmenityListVm>> Handle(GetAmenitiesQuery request, CancellationToken cancellationToken)
        {

            var amenities = await _amenityRepository.GetAmenitiesAsync(request);

            return _mapper.Map<IEnumerable<AmenityListVm>>(amenities);


        }
    }
}
