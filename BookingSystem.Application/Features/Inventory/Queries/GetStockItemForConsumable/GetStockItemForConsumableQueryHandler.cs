using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using BookingSystem.Application.Features.Inventory.Queries.GetStockItem;
using BookingSystem.Domain.Entities.Consumables;
using BookingSystem.Domain.Entities.Inventory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Inventory.Queries.GetStockItemForConsumable
{
    public class GetStockItemForConsumableQueryHandler : IRequestHandler<GetStockItemForConsumableQuery, StockItemVm>
    {
        private readonly IStockItemRepository _stockItemRepository;
        private readonly IAsyncRepository<Consumable> _consumableRepository;
        private readonly IMapper _mapper;
        public GetStockItemForConsumableQueryHandler(IStockItemRepository stockItemRepository, IAsyncRepository<Consumable> consumableRepository,
            IMapper mapper)
        {
            _stockItemRepository = stockItemRepository;
            _consumableRepository = consumableRepository;
            _mapper = mapper;
        }
        public async Task<StockItemVm> Handle(GetStockItemForConsumableQuery request, CancellationToken cancellationToken)
        {
            if(!await _consumableRepository.EntityExistsAsync(request.ConsumableId))
                throw new NotFoundException(nameof(Consumable), request.ConsumableId);

            var stockItem = await _stockItemRepository.GetStockItemByConsumableId(request.ConsumableId);
            if (stockItem == null)
                throw new NotFoundException("StockItem for Consumable",request.ConsumableId);

            return _mapper.Map<StockItemVm>(stockItem);
        }
    }
}
