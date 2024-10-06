using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.StockEnquiry.Commands.CreateStockItemEnquiry
{
    public class CreateStockItemEnquiryCommand: IRequest<Guid>
    {
        public Guid StockEnquiryId { get; set; }
        public Guid ConsumableId { get; set; }
        public int Quantity { get; set; }
    }
}
