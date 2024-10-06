using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.StockEnquiry.Commands.DeleteStockEnquiry
{
    public class DeleteStockEnquiryCommandHandler : IRequestHandler<DeleteStockEnquiryCommand, bool>
    {
        private readonly IStockEnquiryRepository _stockEnquiryRepository;
        public DeleteStockEnquiryCommandHandler(IStockEnquiryRepository stockEnquiryRepository)
        {
            _stockEnquiryRepository = stockEnquiryRepository;
        }
        public async Task<bool> Handle(DeleteStockEnquiryCommand request, CancellationToken cancellationToken)
        {
            if(!await _stockEnquiryRepository.EntityExistsAsync(request.StockEnquiryId))
                throw new NotFoundException(nameof(StockEnquiry), request.StockEnquiryId);
            var stockEnquiry = await _stockEnquiryRepository.GetEntityAsync(request.StockEnquiryId);
            _stockEnquiryRepository.DeleteEntity(stockEnquiry);
            return await _stockEnquiryRepository.SaveChangesAsync();
        }
    }
}
