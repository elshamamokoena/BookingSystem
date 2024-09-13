using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.StockEnquiry.Commands.CreateStockEnquiry
{
    public class CreateStockEnquiryCommand : IRequest<CreateStockEnquiryCommandResponse>
    {
        public Guid BookingId { get; set; }
    }
}
