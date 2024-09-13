using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.ResourceParameters;
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
    public class StockRepository : IStockRepository
    {
        private readonly BookingSystemDbContext _context;

        public StockRepository(BookingSystemDbContext context)
        {
            _context = context;
        }

        public async Task<Stock> AddStock(Stock stock)
        {
            if (stock == null) throw new ArgumentNullException(nameof(stock));

            await _context.Stocks.AddAsync(stock);
            return stock;
        }

        public async Task<StockItem> AddStockItem(StockItem stockItem)
        {
            await _context.StockItems.AddAsync(stockItem);
            return stockItem;
        }

        public void DeleteStock(Stock stock)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<Stock>> GetAllStockAsync(StockResourceParameters resourceParameters)
        //{

        //    if (resourceParameters == null) throw new ArgumentNullException(nameof(resourceParameters));

        //    var collection = _context.Stocks as IQueryable<Stock>;

        //    // ...manipulate the collection later on

        //    return await collection
        //        .Skip(resourceParameters.PageSize * (resourceParameters.PageNumber - 1))
        //        .Take(resourceParameters.PageSize)
        //        .ToListAsync();
        //}

        public async Task<int> GetStockCountAsync()
        {
            return await _context.Stocks.CountAsync();
        }

        public async Task<Stock> GetStockForConsumableAsync(Guid consumableId)
        {
            ArgumentNullException.ThrowIfNull(consumableId, nameof(consumableId));


#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Stocks
                .Include(s => s.StockItems)
                .ThenInclude(si => si.Consumable)
                .FirstOrDefaultAsync(s => s.StockItems.Any(si => si.ConsumableId == consumableId));
#pragma warning restore CS8603 // Possible null reference return.
        }


        //        public async Task<Stock> GetStockForConsumableCategoryAsync(Guid consumableCategoryId)
        //        {
        //            if (consumableCategoryId == Guid.Empty) throw new ArgumentNullException(nameof(consumableCategoryId));

        //#pragma warning disable CS8603 // Possible null reference return.
        //            return await _context.Stocks.
        //                FirstOrDefaultAsync(s => s.ConsumableCategoryId == consumableCategoryId);
        //#pragma warning restore CS8603 // Possible null reference return.
        //        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> StockExistsAsync(Guid stockId)
        {
            return await _context.Stocks.AnyAsync(s => s.StockId == stockId);
        }

        public Task<bool> StockItemIsAvailable(Guid consumableId)
        {
            if(consumableId == Guid.Empty) throw new ArgumentNullException(nameof(consumableId));

            return _context.StockItems.AnyAsync(si => si.ConsumableId == consumableId && si.Quantity > 0);
        }

        public Task<bool> StockItemExistsAsync(Guid stockItemId)
        {
            throw new NotImplementedException();
        }

        public void UpdateStock(Stock stock)
        {
            // Update the stock
        }

        public void UpdateStockItem(StockItem stockItem)
        {
            // changetracker does the most of the work
        }

        public Task<bool> StockItemIsAvailableAsync(Guid consumableId, int quantity)
        {
            ArgumentNullException.ThrowIfNull(consumableId, nameof(consumableId));

            return _context.StockItems
                .AnyAsync(si => si.ConsumableId == consumableId && si.Quantity >= quantity);

        }
    }
}
