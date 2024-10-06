using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Domain.Entities.InternalCart;
using BookingSystem.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Persistence.Repositories
{
    public class CartRepository : BaseRepository<Cart>, ICartRepository
    {
        public CartRepository(BookingSystemDbContext context) : base(context)
        {

        }
    }
}
