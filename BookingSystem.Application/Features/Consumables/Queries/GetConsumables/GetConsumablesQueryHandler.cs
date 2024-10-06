using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Consumables.Queries.GetConsumables
{
    public class GetConsumablesQueryHandler : IRequestHandler<GetConsumablesQuery, IEnumerable<ConsumableListVm>>
    {
        private readonly IConsumableRepository _consumableRepository;
        private readonly IMapper _mapper;

        public GetConsumablesQueryHandler(IConsumableRepository consumableRepository, IMapper mapper)
        {
            _consumableRepository = consumableRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ConsumableListVm>> Handle(GetConsumablesQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));
            var consumables = await _consumableRepository.GetConsumablesAsync(request);
            return _mapper.Map<IEnumerable<ConsumableListVm>>(consumables);
        }
    }
}
