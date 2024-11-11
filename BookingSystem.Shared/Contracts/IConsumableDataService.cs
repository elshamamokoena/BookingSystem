using BookingSystem.ClassLibrary;
using BookingSystem.Shared.Components.Pages.Consumables;
using BookingSystem.Shared.Components.Pages.Events.EditEvents;
using BookingSystem.Shared.Models.Consumables;
using BookingSystem.Shared.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Contracts
{
    public interface IConsumableDataService
    {

        Task<ApiResponse<Guid>> CreateConsumableAsync(ConsumableViewModel consumable);
        Task<List<ConsumableCategoryViewModel>> GetConsumableCategoriesAsync();
        Task<PagedList<ConsumableViewModel>> GetConsumablesAsync(Guid?consumableCategoryId,bool ? includeCategory, int ? pageNumber, int ? pageSize);
        Task<ConsumableViewModel> GetConsumableAsync(Guid consumableId, bool? includeCategory);
        Task<ApiResponse<Guid>> UpdateConsumableAsync(ConsumableViewModel consumable);
        Task<ApiResponse<Guid>> DeleteConsumable(Guid consumableId);
    }
}
