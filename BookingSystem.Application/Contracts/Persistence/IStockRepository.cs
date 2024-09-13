using BookingSystem.Application.ResourceParameters;
using BookingSystem.Domain.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Contracts.Persistence
{
    public interface IStockRepository
    {

        // 1. Room and Amanity Management

        // Get the available stock for a category of consumables
    //    Task<Stock> GetStockForConsumableCategoryAsync(Guid consumableCategoryId);
        //Task<IEnumerable<Stock>> GetAllStockAsync(StockResourceParameters resourceParameters);

        Task<Stock> GetStockForConsumableAsync(Guid consumableId);
        Task<int> GetStockCountAsync();
  
        // Update stock of a consumable item 
        void UpdateStockItem(StockItem stockItem);
        // update availability of stock from here
        void UpdateStock(Stock stock);

        Task<StockItem> AddStockItem(StockItem stockItem);

        //Add a new stock
        Task<Stock> AddStock(Stock stock);

        void DeleteStock(Stock stock);
        Task<bool> StockExistsAsync(Guid stockId);
        Task<bool> StockItemExistsAsync(Guid stockItemId);

        Task<bool> StockItemIsAvailable(Guid consumableId);
        Task<bool> StockItemIsAvailableAsync(Guid consumableId, int quantity);
        public Task<bool> SaveChangesAsync();

    }
}
