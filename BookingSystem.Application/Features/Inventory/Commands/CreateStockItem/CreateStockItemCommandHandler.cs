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

namespace BookingSystem.Application.Features.Inventory.Commands.CreateStockItem
{
    public class CreateStockItemCommandHandler:IRequestHandler<CreateStockItemCommand, CreateStockItemCommandResponse>
    {
     
        private readonly IStockRepository _stockRepository;
        private readonly IMapper mapper;
        private readonly IConsumableRepository _consumableRepository;
        public CreateStockItemCommandHandler(IStockRepository stockRepository, IMapper mapper, IConsumableRepository consumableRepository)
        {
            _stockRepository = stockRepository;
            this.mapper = mapper;
            _consumableRepository = consumableRepository;
        }

        public async Task<CreateStockItemCommandResponse> Handle(CreateStockItemCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateStockItemCommandResponse();
            var validator = new CreateStockItemCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if(validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            if(! await _stockRepository.StockExistsAsync(request.StockId))
                throw new NotFoundException("Stock", request.StockId);

            if(! await _consumableRepository.EntityExistsAsync(request.ConsumableId))
                throw new NotFoundException("Consumable", request.ConsumableId);

            var stockItem = mapper.Map<StockItem>(request);
            stockItem = await _stockRepository.AddStockItem(stockItem);

            if (await _stockRepository.SaveChangesAsync())
            {
                response.StockItem = mapper.Map<StockItemDto>(stockItem);
                response.Message = "Stock Item created successfully";
            }
            else
            { 
                response.Message = "Stock Item creation failed";
            }

            return response;
        }
    }
   
}
