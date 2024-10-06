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

namespace BookingSystem.Application.Features.StockEnquiry.Commands.UpdateStockItemEnquiry
{
    public class UpdateStockItemEnquiryCommandHandler : IRequestHandler<UpdateStockItemEnquiryCommand, UpdateStockItemEnquiryCommandResponse>
    {
        private readonly IStockEnquiryRepository _stockEnquiryRepository;
        private readonly IAsyncRepository<StockItemEnquiry> _stockItemEnquiryRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        public UpdateStockItemEnquiryCommandHandler(IStockEnquiryRepository stockEnquiryRepository, IStockRepository stockRepository,
            IMapper mapper, IAsyncRepository<StockItemEnquiry> stockItemEnquiryRepository)
        {
            _stockEnquiryRepository = stockEnquiryRepository;
            _mapper = mapper;
            _stockRepository = stockRepository;
            _stockItemEnquiryRepository = stockItemEnquiryRepository;
        }
        public  async Task<UpdateStockItemEnquiryCommandResponse> Handle(UpdateStockItemEnquiryCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateStockItemEnquiryCommandResponse();
            var validator = new UpdateStockItemEnquiryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if(validationResult.Errors.Count>0)
                throw new ValidationException(validationResult);

            if(!await _stockEnquiryRepository.EntityExistsAsync(request.StockEnquiryId))
                throw new NotFoundException(nameof(StockEnquiry), request.StockEnquiryId);

            if(!await _stockItemEnquiryRepository.EntityExistsAsync(request.StockItemEnquiryId))
                throw new NotFoundException(nameof(StockItemEnquiry), request.StockItemEnquiryId);

            var stockItemEnquiryToUpdate = await _stockItemEnquiryRepository.GetEntityAsync(request.StockItemEnquiryId);
            var stockItemEnquiry = _mapper.Map(request, stockItemEnquiryToUpdate);
            stockItemEnquiry.IsApproved= await _stockRepository.StockItemIsAvailableAsync(stockItemEnquiry.ConsumableId, stockItemEnquiry.Quantity);
             _stockItemEnquiryRepository.UpdateEntity(stockItemEnquiry);

            if(await _stockEnquiryRepository.SaveChangesAsync())
                response.Message = "Stock Item Enquiry Updated Successfully";
            else
                response.Message = "Stock Item Enquiry Update Failed. Check the errors for more details.";

            return response;

        }
    }
}
