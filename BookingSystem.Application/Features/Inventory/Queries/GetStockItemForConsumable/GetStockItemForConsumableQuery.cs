using BookingSystem.Application.Features.Inventory.Queries.GetStockItem;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Inventory.Queries.GetStockItemForConsumable
{
    public class GetStockItemForConsumableQuery:IRequest<StockItemVm>
    {
        public Guid ConsumableId { get; set; }
    }
}
