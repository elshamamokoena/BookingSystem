using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        void DeleteEntity(T entity); 
        Task<bool> EntityExistsAsync(Guid id);
        Task<T> GetEntityAsync(Guid id);
        Task<bool> SaveChangesAsync();
        void UpdateEntity(T entity);
    }
}
