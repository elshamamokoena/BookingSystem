using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.ConsumableCategories.Queries.GetConsumableCategories
{
    public class GetConsumableCategoriesQueryHandler : IRequestHandler<GetConsumableCategoriesQuery, IEnumerable<ConsumableCategoryListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IConsumableCategoryRepository _consumableCategoryRepository;
        public GetConsumableCategoriesQueryHandler(IMapper mapper, IConsumableCategoryRepository consumableCategoryRepository)
        {
            _mapper = mapper;
            _consumableCategoryRepository = consumableCategoryRepository;
        }
        public async Task<IEnumerable<ConsumableCategoryListVm>> Handle(GetConsumableCategoriesQuery request, CancellationToken cancellationToken)
        {
            var allCategories = ( await _consumableCategoryRepository.ListAllAsync())
                                .OrderBy(x => x.Name)
                                .ToList();
            return _mapper.Map<IEnumerable<ConsumableCategoryListVm>>(allCategories);
        }
    }
}
