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
 
        public Guid ? StockEnquiryId { get; set; }
        public Guid ? BookingId { get; set; }
        public bool ? IncludeStockItemEnquiries { get; set; }
        public bool ? IncludeBooking { get; set; } = false;
    }
}
