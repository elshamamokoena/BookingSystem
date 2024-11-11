using BookingSystem.Domain.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Persistence.Configurations.Stock
{
    public class StockConfiguration : IEntityTypeConfiguration<StockItem>
    {
        public void Configure(EntityTypeBuilder<StockItem> builder)
        {
            builder.Property(s => s.Sku)
                .ValueGeneratedOnAdd()
                .HasValueGenerator<StockNumberGenerator>();
        }
    }
}
