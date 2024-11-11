using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using BookingSystem.Domain.Entities.Consumables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Consumables.Queries.GetConsumable
{
    public class GetConsumableQueryHandler : IRequestHandler<GetConsumableQuery, ConsumableVm>
    {
        private readonly IConsumableRepository _consumableRepository;
        private readonly IMapper _mapper;
        public GetConsumableQueryHandler(IConsumableRepository consumableRepository, IMapper mapper)
        {
            _consumableRepository = consumableRepository;
            _mapper = mapper;
        }

        public async Task<ConsumableVm> Handle(GetConsumableQuery request, CancellationToken cancellationToken)
        {
            if (!await _consumableRepository.EntityExistsAsync(request.ConsumableId))
                throw new NotFoundException(nameof(Consumable), request.ConsumableId);

            var consumable = await _consumableRepository.GetConsumableAsync(request);

            return _mapper.Map<ConsumableVm>(consumable);

        }
    }
}
