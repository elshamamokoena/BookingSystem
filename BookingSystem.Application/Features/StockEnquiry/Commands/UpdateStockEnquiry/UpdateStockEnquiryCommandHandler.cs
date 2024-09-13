using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.StockEnquiry.Commands.UpdateStockEnquiry
{
    public class UpdateStockEnquiryCommandHandler : IRequestHandler<UpdateStockEnquiryCommand, UpdateStockEnquiryCommandResponse>
    {
        private readonly IStockEnquiryRepository _stockEnquiryRepository;
        private readonly IMapper _mapper;
        public UpdateStockEnquiryCommandHandler(IStockEnquiryRepository stockEnquiryRepository,
            IMapper mapper)
        {
            _stockEnquiryRepository = stockEnquiryRepository;
            _mapper = mapper;
        }
        public async Task<UpdateStockEnquiryCommandResponse> Handle(UpdateStockEnquiryCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateStockEnquiryCommandResponse();
            var validator = new UpdateStockEnquiryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            if (!await _stockEnquiryRepository.StockEnquiryExistsAsync(request.StockEnquiryId))
                throw new NotFoundException(nameof(StockEnquiry), request.StockEnquiryId);

            var stockEnquiryToUpdate = await _stockEnquiryRepository.GetStockEnquiryAsync(request.StockEnquiryId);
            var stockEnquiry = _mapper.Map(request, stockEnquiryToUpdate);
             _stockEnquiryRepository.UpdateStockEnquiry(stockEnquiry);
            await _stockEnquiryRepository.SaveChangesAsync();

            if(await _stockEnquiryRepository.SaveChangesAsync())
                response.Message = "Stock Enquiry updated successfully";
            else
                response.Message = "Stock Enquiry update failed";

            return response;
        }
    }
}
