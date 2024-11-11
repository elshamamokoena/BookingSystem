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

namespace BookingSystem.Application.Features.Inventory.Commands.CreateStockItem
{
    public class CreateStockItemCommandHandler:IRequestHandler<CreateStockItemCommand, Guid>
    {

        private readonly IAsyncRepository<StockItem> _stockItemRepository;
        private readonly IMapper _mapper;
        private readonly IConsumableRepository _consumableRepository;

        public CreateStockItemCommandHandler(IAsyncRepository<StockItem> stockItemRepository, 
            IMapper mapper, IConsumableRepository consumableRepository)
        {
            _stockItemRepository = stockItemRepository;
            _mapper = mapper;
            _consumableRepository = consumableRepository;
        }

        public async Task<Guid> Handle(CreateStockItemCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateStockItemCommandValidator();
            var validationResult = await validator.ValidateAsync(request,cancellationToken);

            if(validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            if (!await _consumableRepository.EntityExistsAsync(request.ConsumableId))
                    throw new NotFoundException(nameof(Consumable), request.ConsumableId);

            var stockItem = await _stockItemRepository
                .AddAsync(_mapper.Map<StockItem>(request));

            await _stockItemRepository.SaveChangesAsync();

            return stockItem.StockItemId;
        }
    }
   
}
