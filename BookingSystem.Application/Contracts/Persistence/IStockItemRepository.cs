using BookingSystem.Application.Features.Inventory.Queries.GetStockItem;
using BookingSystem.Domain.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Contracts.Persistence
{
    public interface IStockItemRepository:IAsyncRepository<StockItem>
    {
        Task<StockItem> GetStockItemAsync(GetStockItemQuery query);
        Task<StockItem> GetStockItemByConsumableId(Guid consumableId);
        Task<bool> IsInStock(Guid consumableId);

    }
}
