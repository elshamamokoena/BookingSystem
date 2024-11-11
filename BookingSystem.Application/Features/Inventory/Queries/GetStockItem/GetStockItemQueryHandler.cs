using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using BookingSystem.Domain.Entities.Consumables;
using BookingSystem.Domain.Entities.Inventory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Inventory.Queries.GetStockItem
{
    public class GetStockItemQueryHandler : IRequestHandler<GetStockItemQuery, StockItemVm>
    {
        private readonly IMapper _mapper;
        private readonly IStockItemRepository _stockItemRepository;
        private readonly IAsyncRepository<Consumable> _consumableRepository;

        public GetStockItemQueryHandler(IMapper mapper,
            IStockItemRepository stockItemRepository, IAsyncRepository<Consumable> consumableRepository)
        {
            _mapper = mapper;
            _stockItemRepository = stockItemRepository;
            _consumableRepository = consumableRepository;
        }

        public async Task<StockItemVm> Handle(GetStockItemQuery request, CancellationToken cancellationToken)
        {
            if (!await _stockItemRepository.EntityExistsAsync(request.StockItemId))
                throw new NotFoundException("StockItem", request.StockItemId);

            return _mapper
                .Map<StockItemVm>(await _stockItemRepository.GetStockItemAsync(request));
        }
    }
}
