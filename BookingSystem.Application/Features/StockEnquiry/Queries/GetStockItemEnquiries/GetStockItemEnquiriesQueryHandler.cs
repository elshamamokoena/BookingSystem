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
    public class GetStockItemEnquiriesQueryHandler : IRequestHandler<GetStockItemEnquiriesQuery, StockItemEnquiryListVm>
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
        public async Task<StockItemEnquiryListVm> Handle(GetStockItemEnquiriesQuery request, CancellationToken cancellationToken)
        {
            if(! await _stockEnquiryRepository.StockEnquiryExistsAsync(request.StockEnquiryId))
                throw new NotFoundException(nameof(StockEnquiry), request.StockEnquiryId);

            // Get Stock Enquiry
            var stockEnquiry = await _stockEnquiryRepository.GetStockEnquiryAsync(request.StockEnquiryId);

            // Get Stock Item Enquiries
            var stockItemEnquiries = await _stockEnquiryRepository.GetStockItemEnquiriesAsync(request);
            var stockItemEnqueriesToReturn = _mapper.Map<IEnumerable<StockItemEnquiryDto>>(stockItemEnquiries);

            return new StockItemEnquiryListVm
            {
                StockItemEnquiries = stockItemEnqueriesToReturn,
                BookingId = stockEnquiry.BookingId,
                StockEnquiryId = stockEnquiry.StockEnquiryId,
                AllApproved = !stockItemEnquiries.Any(x => x.IsApproved == false)
            };

        }
    }
}
