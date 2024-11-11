using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using BookingSystem.Domain.Entities.Inventory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Inventory.Commands.DeleteStockItem
{
    public class DeleteStockItemCommandHandler : IRequestHandler<DeleteStockItemCommand, Unit>
    {
        private readonly IAsyncRepository<StockItem> _stockItemRepository;
        private readonly IMapper _mapper;

     
        public DeleteStockItemCommandHandler(IAsyncRepository<StockItem> stockItemRepository, IMapper mapper)
        {
            _stockItemRepository = stockItemRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteStockItemCommand request, CancellationToken cancellationToken)
        {
            var stockItem = await _stockItemRepository.GetEntityAsync(request.StockItemId);
            if (stockItem == null) 
                throw new NotFoundException(nameof(StockItem),request.StockItemId);

            _stockItemRepository.DeleteEntity(stockItem);

            await _stockItemRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
