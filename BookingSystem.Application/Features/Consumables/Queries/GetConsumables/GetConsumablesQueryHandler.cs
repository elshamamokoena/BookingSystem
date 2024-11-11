using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using BookingSystem.Application.Features.Inventory.Queries.GetStockItem;
using BookingSystem.Domain.Entities.Consumables;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Consumables.Queries.GetConsumables
{
    public class GetConsumablesQueryHandler : IRequestHandler<GetConsumablesQuery, ConsumableListVm>
    {
        private readonly IConsumableRepository _consumableRepository;
        private readonly IStockItemRepository _stockItemRepository;
        private readonly IMapper _mapper;

        public GetConsumablesQueryHandler(IConsumableRepository consumableRepository, 
            IStockItemRepository stockItemRepository,
            IMapper mapper)
        {
            _consumableRepository = consumableRepository;
            _stockItemRepository = stockItemRepository;
            _mapper = mapper;
        }
        public async Task<ConsumableListVm> Handle(GetConsumablesQuery request, CancellationToken cancellationToken)
        {
            if (request.ConsumableCategoryId.HasValue && request.ConsumableCategoryId.Value == Guid.Empty)
                throw new BadRequestException($"{nameof(ConsumableCategory)} ID ({request.ConsumableCategoryId.Value}) cannot be empty.");

            var consumables = await _consumableRepository.GetConsumablesAsync(request);

            var consumablesToReturn = _mapper.Map<List<ConsumableListDto>>(consumables);

            foreach(var consumable in consumablesToReturn)
                consumable.IsInStock = await _stockItemRepository.IsInStock(consumable.ConsumableId);

            return new ConsumableListVm
            {
                Count = consumables.TotalCount,
                PageNumber = consumables.PageIndex,
                PageSize = consumables.PageSize,
                Consumables = consumablesToReturn,
            };
        }

    }
}
