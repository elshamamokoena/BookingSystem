using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Domain.Entities.Consumables;
using BookingSystem.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Persistence.Repositories
{
    public class ConsumableCategoryRepository : BaseRepository<ConsumableCategory>, IConsumableCategoryRepository
    {
        public ConsumableCategoryRepository(BookingSystemDbContext context) : base(context)
        {
        }
    }
}
