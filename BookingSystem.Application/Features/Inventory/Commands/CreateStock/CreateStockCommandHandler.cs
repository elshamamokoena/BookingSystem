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

namespace BookingSystem.Application.Features.Inventory.Commands.CreateStock
{
    public class CreateStockCommandHandler : IRequestHandler<CreateStockCommand, CreateStockCommandResponse>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IConsumableRepository _consumableRepository;
        private readonly IMapper _mapper;

        public CreateStockCommandHandler(IStockRepository stockRepository, IMapper mapper,
            IConsumableRepository consumableRepository)
        {
            _stockRepository = stockRepository;
            _consumableRepository = consumableRepository;
            _mapper = mapper;
        }
        public async Task<CreateStockCommandResponse> Handle(CreateStockCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateStockCommandResponse();
            var validator = new CreateStockCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if(validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);


            var stock = _mapper.Map<Stock>(request);
            stock = await _stockRepository.AddStock(stock);
            await _stockRepository.SaveChangesAsync();
            response.Stock = _mapper.Map<StockDto>(stock);
            response.Message = "Stock created successfully";

            return response;
        }
    }
}
