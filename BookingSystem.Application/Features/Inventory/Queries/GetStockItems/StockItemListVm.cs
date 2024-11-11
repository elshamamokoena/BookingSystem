using BookingSystem.Application.Models;

namespace BookingSystem.Application.Features.Inventory.Queries.GetStockItems
{
    public class StockItemListVm:PagedVm
    {
        public Guid StockItemId { get; set; }
        public Guid ConsumableId { get; set; }
    }
}