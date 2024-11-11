using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Features.Inventory.Queries.GetStockItem;
using BookingSystem.Domain.Entities.Inventory;
using BookingSystem.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Persistence.Repositories
{
    public class StockItemRepository : BaseRepository<StockItem>, IStockItemRepository
    {
        public StockItemRepository(BookingSystemDbContext context) : base(context)
        {
        }

        public async Task<StockItem> GetStockItemAsync(GetStockItemQuery query)
        {
            ArgumentNullException.ThrowIfNull(query);

            var stockItem = _context.StockItems.AsQueryable();

            if (query.IncludeConsumable.HasValue && query.IncludeConsumable.Value)
                stockItem = stockItem.Include(i => i.Consumable);

#pragma warning disable CS8603 // Possible null reference return.
            return await stockItem
                .FirstOrDefaultAsync(i => i.StockItemId == query.StockItemId);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<StockItem> GetStockItemByConsumableId(Guid consumableId)
        {
            ArgumentNullException.ThrowIfNull(consumableId);
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.StockItems
                .FirstOrDefaultAsync(i => i.ConsumableId == consumableId);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<bool> IsInStock(Guid consumableId)
        {
            ArgumentNullException.ThrowIfNull(consumableId);
            var stockitem = await GetStockItemByConsumableId(consumableId);
            if (stockitem == null)
                return false;

            return (stockitem.Quantity > 0);
        }
    }
}
