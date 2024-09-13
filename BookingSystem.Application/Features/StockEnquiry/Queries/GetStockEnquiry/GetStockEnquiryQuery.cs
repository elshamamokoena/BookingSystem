using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.StockEnquiry.Queries.GetStockEnquiry
{
    public class GetStockEnquiryQuery: IRequest<StockEnquiryVm>
    {
        public GetStockEnquiryQuery() { }
        public GetStockEnquiryQuery(Guid stockEnquiryId, 
            bool? includeStockItemEnquiries, bool? includeBooking)
        {
            StockEnquiryId = stockEnquiryId;
            IncludeStockItemEnquiries = includeStockItemEnquiries;
            IncludeBooking = includeBooking;
        }

        public Guid StockEnquiryId { get; set; }
        public bool ? IncludeStockItemEnquiries { get; set; }
        public bool ? IncludeBooking { get; set; } = false;
    }
}
