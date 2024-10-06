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

    }
}
