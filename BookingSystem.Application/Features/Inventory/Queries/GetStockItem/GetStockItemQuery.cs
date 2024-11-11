using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Inventory.Queries.GetStockItem
{
    public class GetStockItemQuery:IRequest<StockItemVm>
    {
        public Guid StockItemId { get; set; }
        public bool? IncludeConsumable { get; set; }
    }
}
