using BookingSystem.Application.Contracts.Services;
using BookingSystem.Domain.Common;
using BookingSystem.Domain.Entities.Consumables;
using BookingSystem.Domain.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Inventory.Persistence.DbContexts
{
    public class InventoryDbContext : DbContext
    {
        private readonly IAuthenticatedUserService _authenticatedUserService;
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options, 
            IAuthenticatedUserService authenticatedUserService): base(options)
        {
            _authenticatedUserService = authenticatedUserService;
        }
        public DbSet<ConsumableCategory> ConsumableCategories { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockItem> StockItems { get; set; }

        protected override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {

            foreach (var entry in ChangeTracker.Entries<Auditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "Admin";
                        entry.Entity.Created = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = "Admin";
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }

            }
        }
    }
}