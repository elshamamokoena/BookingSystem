using BookingSystem.Application.ResourceParameters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.StockEnquiry.Queries.GetStockItemEnquiries
{
    public class GetStockItemEnquiriesQuery:ResourceParameterBase, IRequest<IEnumerable<StockItemEnquiryListVm>>
    {
        public Guid StockEnquiryId { get; set; }
        public bool ? IsApproved { get; set; }
    }
}
