using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.StockEnquiry.Commands.UpdateStockItemEnquiry
{
    public class UpdateStockItemEnquiryCommand:IRequest<UpdateStockItemEnquiryCommandResponse>
    {
        public Guid StockEnquiryId { get; set; }
        public Guid StockItemEnquiryId { get; set; }
        public int Quantity { get; set; }
    }
}
