using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Domain.Entities.Amenities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Amenities.Queries.GetAmenityCategories
{
    public class GetAmenityCategoriesQueryHandler : IRequestHandler<GetAmenityCategoriesQuery, IEnumerable<AmenityCategoryListVm>>
    {
        private readonly IAsyncRepository<AmenityCategory> _amenityCategoryRepository;
        private readonly IMapper _mapper;
        public GetAmenityCategoriesQueryHandler(IAsyncRepository<AmenityCategory> amenityCategoryRepository, IMapper mapper)
        {
            _amenityCategoryRepository = amenityCategoryRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AmenityCategoryListVm>> Handle(GetAmenityCategoriesQuery request, CancellationToken cancellationToken)
        {
            var allAmenityCategories = (await _amenityCategoryRepository.ListAllAsync())
                                    .OrderBy(ac => ac.Name);

            return _mapper.Map<IEnumerable<AmenityCategoryListVm>>(allAmenityCategories);
        }
    }
}
