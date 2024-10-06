using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.StockEnquiry.Commands.CreateStockEnquiry
{
    public class CreateStockEnquiryCommandHandler : IRequestHandler<CreateStockEnquiryCommand, Guid>
    {
        private readonly IStockEnquiryRepository _stockEnquiryRepository;
        private readonly IMapper _mapper;

        public CreateStockEnquiryCommandHandler(IStockEnquiryRepository stockEnquiryRepository,
            IMapper mapper)
        {
            _stockEnquiryRepository = stockEnquiryRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateStockEnquiryCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateStockEnquiryCommandResponse();
            var validator = new CreateStockEnquiryCommandValidator();
            var validationResult = await validator.ValidateAsync(request, new CancellationToken());

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var stockEnquiry = _mapper.Map<Domain.Entities.Inventory.StockEnquiry>(request);
            stockEnquiry = await _stockEnquiryRepository.AddAsync(stockEnquiry);
            await _stockEnquiryRepository.SaveChangesAsync();
            //response.StockEnquiry = _mapper.Map<StockEnquiryDto>(stockEnquiry);
            return stockEnquiry.StockEnquiryId;
        }
    }
}
