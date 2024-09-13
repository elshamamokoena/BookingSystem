using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.StockEnquiry.Queries.GetStockEnquiries
{
    public class GetStockEnquiriesQueryHandler : IRequestHandler<GetStockEnquiriesQuery, StockEnquiryListVm>
    {
        private readonly IStockEnquiryRepository _stockEnquiryRepository;
        private readonly IEventRepository _bookingRepository;
        private readonly IMapper _mapper;
        public GetStockEnquiriesQueryHandler(IStockEnquiryRepository stockEnquiryRepository,
            IMapper mapper, IEventRepository bookingRepository)
        {
            _stockEnquiryRepository = stockEnquiryRepository;
            _mapper = mapper;
            _bookingRepository = bookingRepository;
        }
        public async Task<StockEnquiryListVm> Handle(GetStockEnquiriesQuery request, CancellationToken cancellationToken)
        {
                //if (!await _bookingRepository.EntityExistsAsync(request.BookingId))
                    throw new NotFoundException(nameof(StockEnquiry), request.BookingId);


            var stockEnquiries = await _stockEnquiryRepository.GetStockEnquiriesAsync(request);
            var stockEnquiriesDto = _mapper.Map<IEnumerable<ForListStockEnquiryDto>>(stockEnquiries);

            return new StockEnquiryListVm(stockEnquiriesDto);

        }
    }
}
