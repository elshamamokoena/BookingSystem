using BookingSystem.Shared.Components.Pages.Consumables.EditConsumablePage.EditConsumablePageComponents;
using BookingSystem.Shared.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Contracts
{
    public interface IStockDataService
    {
        Task<StockItemViewModel> GetStockItemAsync(Guid? stockItemId, Guid? consumableId, bool? includeConsumable);
        Task<StockItemViewModel> GetStockItemForConsumableAsync(Guid consumableId);

        Task<ApiResponse<Guid>> CreateStockItemAsync(StockItemViewModel stockItem);
        Task<ApiResponse<Guid>> UpdateStockItemAsync(StockItemViewModel stockItem);
        Task<ApiResponse<Guid>> DeleteStockItemAsync(Guid stockItemId);

    }
}
