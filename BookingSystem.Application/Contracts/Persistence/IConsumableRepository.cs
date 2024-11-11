using BookingSystem.Application.Features.Consumables.Queries.GetConsumable;
using BookingSystem.Application.Features.Consumables.Queries.GetConsumables;
using BookingSystem.Application.Helpers;
using BookingSystem.Application.ResourceParameters;
using BookingSystem.ClassLibrary;
using BookingSystem.Domain.Entities.Consumables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Contracts.Persistence
{
    public interface IConsumableRepository:IAsyncRepository<Consumable>
    {
        Task<PaginatedList<Consumable>> GetConsumablesAsync(GetConsumablesQuery query);
        Task<Consumable> GetConsumableAsync(GetConsumableQuery query);


        //void AddConsumableCategory(ConsumableCategory consumableCategory);
        //void DeleteConsumableCategory(ConsumableCategory consumableCategory);
        //void UpdateConsumableCategory(ConsumableCategory consumableCategory);
        //Task<IEnumerable<ConsumableCategory>> GetConsumableCategoriesAsync(GetConsun resourceParameters);
        //Task<int> GetConsumableCategoriesCountAsync();
        //Task<ConsumableCategory> GetConsumableCategoryAsync(Guid consumableCategoryId);

        //Task<Consumable> AddConsumableAsync(Consumable consumable);
        //void DeleteConsumable(Consumable consumable);
        //void UpdateConsumable(Consumable consumable);
        //Task<IEnumerable<Consumable>> GetConsumablesAsync(Guid consumableCategoryId);
        //Task<int> GetConsumablesCountAsync(Guid consumableCategoryId);
        //Task<Consumable> GetConsumableAsync(Guid consumableCategoryId, Guid consumableId);

        //Task<bool> ConsumableCategoryExists(Guid consumableCategoryId);
        //Task<bool> SaveChangesAsync();
        //Task<ConsumableCategory> AddConsumableCategoryAsync(ConsumableCategory consumableCategory);
        //Task<bool> ConsumableExistsAsync(Guid consumableId);
    }
}
