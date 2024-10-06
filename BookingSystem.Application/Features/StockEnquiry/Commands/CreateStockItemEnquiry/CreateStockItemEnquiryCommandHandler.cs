using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using BookingSystem.Application.Features.StockEnquiry.Queries.GetStockEnquiry;
using BookingSystem.Domain.Entities.Consumables;
using BookingSystem.Domain.Entities.Inventory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.StockEnquiry.Commands.CreateStockItemEnquiry
{
    public class CreateStockItemEnquiryCommandHandler : IRequestHandler<CreateStockItemEnquiryCommand,
        Guid>
    {
        private readonly IStockEnquiryRepository _stockEnquiryRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IConsumableRepository _consumableRepository;
        private readonly IAsyncRepository<StockItemEnquiry> _stockItemEnquiryRepository;
        private readonly IMapper _mapper;
        public CreateStockItemEnquiryCommandHandler(IStockEnquiryRepository stockEnquiryRepository, 
            IAsyncRepository<StockItemEnquiry> stockItemEnquiryRepository,
            IConsumableRepository consumableRepository, IMapper mapper, IStockRepository stockRepository)
        {
            _stockItemEnquiryRepository = stockItemEnquiryRepository;
            _stockEnquiryRepository = stockEnquiryRepository;
            _consumableRepository = consumableRepository;
            _mapper = mapper;
            _stockRepository = stockRepository;
        }
        public async Task<Guid>  Handle(CreateStockItemEnquiryCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateStockItemEnquiryCommandResponse();
            var validator = new CreateStockItemEnquiryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if(validationResult.Errors.Count>0)
                throw new ValidationException(validationResult);

            if (!await _stockEnquiryRepository.EntityExistsAsync(request.StockEnquiryId))
                throw new NotFoundException(nameof(StockEnquiry), request.StockEnquiryId);

            if(!await _consumableRepository.EntityExistsAsync(request.ConsumableId))
                throw new NotFoundException(nameof(Consumable), request.ConsumableId);

            var stockItemEnquiry = _mapper.Map<StockItemEnquiry>(request);

            stockItemEnquiry.IsApproved = await _stockRepository.StockItemIsAvailableAsync(request.ConsumableId, request.Quantity);
            stockItemEnquiry = await _stockItemEnquiryRepository.AddAsync(stockItemEnquiry);
            await _stockEnquiryRepository.SaveChangesAsync();


            return stockItemEnquiry.StockItemEnquiryId;
        }
    }
   
}
