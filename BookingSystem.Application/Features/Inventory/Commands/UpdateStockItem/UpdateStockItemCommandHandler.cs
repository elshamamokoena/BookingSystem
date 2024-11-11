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

namespace BookingSystem.Application.Features.Inventory.Commands.UpdateStockItem
{
    public class UpdateStockItemCommandHandler : IRequestHandler<UpdateStockItemCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<StockItem> _stockItemRepository;
        public UpdateStockItemCommandHandler(IMapper mapper, IAsyncRepository<StockItem> stockItemRepository)
        {
            _mapper = mapper;
            _stockItemRepository = stockItemRepository;
        }

        public async Task<Unit> Handle(UpdateStockItemCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateStockItemCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var stockItem = await _stockItemRepository.GetEntityAsync(request.StockItemId);
            if (stockItem == null)
                throw new NotFoundException(nameof(StockItem), request.StockItemId);

            _mapper.Map(request, stockItem, typeof(UpdateStockItemCommand), typeof(StockItem));
            _stockItemRepository.UpdateEntity(stockItem);



            await _stockItemRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
