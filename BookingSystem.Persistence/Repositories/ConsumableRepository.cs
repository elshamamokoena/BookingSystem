using Azure.Core;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Features.Consumables.Queries.GetConsumable;
using BookingSystem.Application.Features.Consumables.Queries.GetConsumables;
using BookingSystem.Application.Helpers;
using BookingSystem.Application.ResourceParameters;
using BookingSystem.Domain.Entities.Consumables;
using BookingSystem.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Persistence.Repositories
{
    public class ConsumableRepository :BaseRepository<Consumable>, IConsumableRepository
    {
        public ConsumableRepository(BookingSystemDbContext context): base(context)
        {
        }

        public Task<Consumable> GetConsumableAsync(GetConsumableQuery query)
        {
            ArgumentNullException.ThrowIfNull(nameof(GetConsumableQuery), nameof(query));
            var consumable = _context.Consumables as IQueryable<Consumable>;

            if (query.IncludeCategory.HasValue && query.IncludeCategory.Value)
                consumable = consumable.Include(c => c.Category);

#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            return consumable
                .FirstOrDefaultAsync(c=>c.ConsumableId==query.ConsumableId);
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.

        }

        public async Task<PaginatedList<Consumable>> GetConsumablesAsync(GetConsumablesQuery query)
        {
            ArgumentNullException.ThrowIfNull(nameof(GetConsumablesQuery), nameof(query));

            var consumables = _context.Consumables as IQueryable<Consumable>;

            if(query.ConsumableCategoryId.HasValue && query.ConsumableCategoryId != Guid.Empty)
                consumables = consumables.Where(x => x.ConsumableCategoryId == query.ConsumableCategoryId);

            if (query.IncludeCategory.HasValue && query.IncludeCategory.Value)
                consumables = consumables.Include(x => x.Category);

            return await PaginatedList<Consumable>
                .CreateAsync(consumables, query.PageNumber, query.PageSize);

            //return await consumables.
            //   OrderBy(x => x.Name)
            //    .Skip(query.PageSize * (query.PageNumber - 1))
            //    .Take(query.PageSize)

            //    .ToListAsync();
        }




        //        public async Task<Consumable> AddConsumableAsync(Consumable consumable)
        //        {
        //            ArgumentNullException.ThrowIfNull(consumable, nameof(consumable));

        //            await _context.Consumables.AddAsync(consumable);
        //            return consumable;
        //        }

        //        public void AddConsumableCategory(ConsumableCategory consumableCategory)
        //        {
        //            ArgumentNullException.ThrowIfNull(consumableCategory, nameof(consumableCategory));
        //            _context.ConsumableCategories.Add(consumableCategory);
        //        }

        //        public async Task<ConsumableCategory> AddConsumableCategoryAsync(ConsumableCategory consumableCategory)
        //        {
        //            await  _context.ConsumableCategories.AddAsync(consumableCategory);
        //            return consumableCategory;
        //        }

        //        public async Task<bool> ConsumableCategoryExists(Guid consumableCategoryId)
        //        {
        //            return await _context.ConsumableCategories
        //                .AnyAsync(c => c.ConsumableCategoryId == consumableCategoryId);
        //        }

        //        public async Task<bool> ConsumableExistsAsync(Guid consumableId)
        //        {
        //            return await _context.Consumables
        //                .AnyAsync(c => c.ConsumableId == consumableId);
        //        }

        //        public void DeleteConsumable(Consumable consumable)
        //        {
        //            _context.Consumables.Remove(consumable);
        //        }

        //        public void DeleteConsumableCategory(ConsumableCategory consumableCategory)
        //        {
        //            _context.ConsumableCategories.Remove(consumableCategory);
        //        }

        //        public async Task<Consumable> GetConsumableAsync(Guid consumableCategoryId, Guid consumableId)
        //        {
        //            if (consumableCategoryId == Guid.Empty) throw new ArgumentNullException(nameof(consumableCategoryId));
        //            if (consumableId == Guid.Empty) throw new ArgumentNullException(nameof(consumableId));

        //#pragma warning disable CS8603 // Possible null reference return.
        //            return await _context.Consumables
        //                .Where(c => c.ConsumableCategoryId == consumableCategoryId
        //                && c.ConsumableId == consumableId).FirstOrDefaultAsync();
        //#pragma warning restore CS8603 // Possible null reference return.
        //        }

        //        //public async Task<IEnumerable<ConsumableCategory>> GetConsumableCategoriesAsync(ConsumableCategoriesResourceParameters resourceParameters)
        //        //{
        //        //    if (resourceParameters == null) throw new ArgumentNullException(nameof(resourceParameters));

        //        //    var collection = _context.ConsumableCategories as IQueryable<ConsumableCategory>;

        //        //    //...

        //        //    return await collection
        //        //        .Skip(resourceParameters.PageSize * (resourceParameters.PageNumber - 1))
        //        //        .Take(resourceParameters.PageSize)
        //        //        .ToListAsync();
        //        //}

        //        public async Task<int> GetConsumableCategoriesCountAsync()
        //        {
        //            return await _context.ConsumableCategories.CountAsync();
        //        }

        //        public async Task<ConsumableCategory> GetConsumableCategoryAsync(Guid consumableCategoryId)
        //        {
        //            if (consumableCategoryId == Guid.Empty) throw new ArgumentNullException(nameof(consumableCategoryId));

        //#pragma warning disable CS8603 // Possible null reference return.
        //            return await _context.ConsumableCategories
        //                .FirstOrDefaultAsync(c => c.ConsumableCategoryId == consumableCategoryId);
        //#pragma warning restore CS8603 // Possible null reference return.
        //        }

        //        public async Task<IEnumerable<Consumable>> GetConsumablesAsync(Guid consumableCategoryId)
        //        {
        //            if (consumableCategoryId == Guid.Empty) throw new ArgumentNullException(nameof(consumableCategoryId));

        //            return await _context.Consumables
        //                .Where(c => c.ConsumableCategoryId == consumableCategoryId).ToListAsync();
        //        }

        //        public async Task<int> GetConsumablesCountAsync(Guid consumableCategoryId)
        //        {
        //            return await _context.Consumables
        //                .Where(c => c.ConsumableCategoryId == consumableCategoryId)
        //                .CountAsync();
        //        }

        //        public async Task<bool> SaveChangesAsync()
        //        {
        //            return await _context.SaveChangesAsync() > 0;
        //        }

        //        public void UpdateConsumable(Consumable consumable)
        //        {
        //            // Update the consumable
        //        }

        //        public void UpdateConsumableCategory(ConsumableCategory consumableCategory)
        //        {
        //            // Update the consumable category
        //        }
    }
}
