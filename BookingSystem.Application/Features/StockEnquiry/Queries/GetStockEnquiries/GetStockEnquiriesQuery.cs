using BookingSystem.Application.ResourceParameters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.StockEnquiry.Queries.GetStockEnquiries
{
    public class GetStockEnquiriesQuery:ResourceParameterBase, IRequest<StockEnquiryListVm>
    {
        public Guid BookingId { get; set; }
        public bool  IsApproved { get; set; } 

    }
}
