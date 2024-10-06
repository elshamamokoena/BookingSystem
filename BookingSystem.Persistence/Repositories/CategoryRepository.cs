using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Domain.Entities.Events;
using BookingSystem.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BookingSystemDbContext context) : base(context)
        {
        }
    }
}
