using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.StockEnquiry.Commands.DeleteStockEnquiry
{
    public class DeleteStockEnquiryCommand : IRequest<bool>
    {
        public Guid StockEnquiryId { get; set; }
    }
}
