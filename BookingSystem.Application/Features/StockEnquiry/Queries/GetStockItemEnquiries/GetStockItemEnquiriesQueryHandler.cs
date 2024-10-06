using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using BookingSystem.Application.Features.StockEnquiry.Queries.GetStockEnquiry;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.StockEnquiry.Queries.GetStockItemEnquiries
{
    public class GetStockItemEnquiriesQueryHandler : IRequestHandler<GetStockItemEnquiriesQuery,IEnumerable<StockItemEnquiryListVm>>
    {
        private readonly IStockEnquiryRepository _stockEnquiryRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public GetStockItemEnquiriesQueryHandler(IStockEnquiryRepository stockEnquiryRepository, 
            IStockRepository stockRepository, IMapper mapper)
        {
            _stockEnquiryRepository = stockEnquiryRepository;
            _stockRepository = stockRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<StockItemEnquiryListVm>> Handle(GetStockItemEnquiriesQuery request, CancellationToken cancellationToken)
        {
            if(! await _stockEnquiryRepository.EntityExistsAsync(request.StockEnquiryId))
                throw new NotFoundException(nameof(StockEnquiry), request.StockEnquiryId);
            // Get Stock Item Enquiries
            var stockItemEnquiries = await _stockEnquiryRepository.GetStockItemEnquiriesAsync(request);
            return _mapper.Map<IEnumerable<StockItemEnquiryListVm>>(stockItemEnquiries);
        }
    }
}
