using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Inventory.Commands.UpdateStockItem
{
    public class UpdateStockItemCommand:IRequest<Unit>
    {
        public Guid StockItemId { get; set; }
        public int Quantity { get; set; }
        public string Sku { get; set; } = string.Empty;
    }
}
