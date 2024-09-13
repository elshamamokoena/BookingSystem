using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.StockEnquiry.Commands.UpdateStockEnquiry
{
    public class UpdateStockEnquiryCommand:IRequest<UpdateStockEnquiryCommandResponse>
    {
        public Guid StockEnquiryId { get; set; }
        public bool IsApproved { get; set; }
    }
}
