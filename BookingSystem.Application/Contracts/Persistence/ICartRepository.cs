using BookingSystem.Domain.Entities.InternalCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Contracts.Persistence
{
    public interface ICartRepository:IAsyncRepository<Cart>
    {
        Task ClearCart(Guid cartId);
        Task<Cart> GetCartAsync(Guid cartId, bool? includeCartItems);


    }
}
