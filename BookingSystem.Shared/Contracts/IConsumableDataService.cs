using BookingSystem.Shared.Components.Pages.Consumables;
using BookingSystem.Shared.Components.Pages.Events.EditEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Contracts
{
    public interface IConsumableDataService
    {
        Task<List<ConsumableCategoryViewModel>> GetConsumableCategories();
        Task<List<ConsumableViewModel>> GetConsumables(bool ? includeCategory, int ? pageNumber, int ? pageSize);

    }
}
