using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using BookingSystem.Application.Features.StockEnquiry.Queries.GetStockItemEnquiries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.StockEnquiry.Queries.GetStockEnquiry
{
    public class GetStockEnquiryQueryHandler : IRequestHandler<GetStockEnquiryQuery, StockEnquiryVm>
    {
        private readonly IStockEnquiryRepository _stockEnquiryRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        public GetStockEnquiryQueryHandler(IStockEnquiryRepository stockEnquiryRepository,
            IMapper mapper, IStockRepository stockRepository)
        {
            _stockEnquiryRepository = stockEnquiryRepository;
            _stockRepository = stockRepository;
            _mapper = mapper;
        }
        public async Task<StockEnquiryVm> Handle(GetStockEnquiryQuery request, CancellationToken cancellationToken)
        {
            if(!await _stockEnquiryRepository.StockEnquiryExistsAsync(request.StockEnquiryId))
                throw new NotFoundException(nameof(StockEnquiry), request.StockEnquiryId);

            var stockEnquiry = await _stockEnquiryRepository.GetStockEnquiryAsync(request);
            var stockEnquiryVm = _mapper.Map<StockEnquiryVm>(stockEnquiry);
            var enquiries = await _stockEnquiryRepository
                .GetStockItemEnquiriesAsync(new GetStockItemEnquiriesQuery { StockEnquiryId = stockEnquiry.StockEnquiryId});

      


            //validate if all stock item enquiries are approved
            stockEnquiryVm.IsApproved = !enquiries.Any(x => x.IsApproved == false);

            //stockEnquiryVm.IsApproved = (await _stockEnquiryRepository
            //    .GetStockItemEnquiriesAsync(request.StockEnquiryId))
            //    .Any();
            return stockEnquiryVm;
        }
    }
}
