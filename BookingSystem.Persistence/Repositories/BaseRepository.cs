using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Persistence.Repositories
{
     public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly BookingSystemDbContext _context;
        public BaseRepository(BookingSystemDbContext context)
        {
            _context = context;
        }


        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public void DeleteEntity(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<bool> EntityExistsAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id) != null;
        }

        public virtual async Task<T> GetEntityAsync(Guid id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Set<T>().FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateEntity(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
