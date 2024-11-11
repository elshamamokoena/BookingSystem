using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Domain.Entities.InternalCart;
using BookingSystem.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Persistence.Repositories
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(BookingSystemDbContext context) 
            : base(context)
        {

        }

        public async Task ClearCart(Guid cartId)
        {
            ArgumentNullException.ThrowIfNull(cartId, nameof(cartId));
            var itemsToRemove =  _context.CartItems.Where(x => x.CartId == cartId);
            _context.CartItems.RemoveRange(itemsToRemove);
            await _context.SaveChangesAsync();

            //////////////////////////
            //manage cart status here/
            //////////////////////////
        }

        public async Task<Cart> GetCartAsync(Guid cartId, bool ? includeCartItems)
        {
            ArgumentNullException.ThrowIfNull(cartId, nameof(cartId));

            var cart = _context.InternalCarts.AsQueryable();

            if (includeCartItems.HasValue && includeCartItems.Value)
                cart = cart.Include(ci => ci.CartItems)
                        .ThenInclude(i=>i.Consumable);

#pragma warning disable CS8603 // Possible null reference return.
            return await cart
                .FirstOrDefaultAsync(c => c.CartId == cartId);
#pragma warning restore CS8603 // Possible null reference return.

        }
    }
}
