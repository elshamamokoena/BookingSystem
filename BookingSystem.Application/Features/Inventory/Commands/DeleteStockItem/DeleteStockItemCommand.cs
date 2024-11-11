using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Inventory.Commands.DeleteStockItem
{
    public class DeleteStockItemCommand:IRequest<Unit>
    {
        public Guid StockItemId { get; set; }
    }
}
