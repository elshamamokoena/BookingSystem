using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Inventory.Commands.CreateStockItem
{
    public class CreateStockItemCommand: IRequest<Guid>
    {
        public Guid ConsumableId { get; set; }
        public string Sku { get; set; } = string.Empty;
        public int Quantity { get; set; }

    }
}
