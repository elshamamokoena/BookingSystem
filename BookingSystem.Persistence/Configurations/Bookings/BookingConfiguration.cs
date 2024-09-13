using BookingSystem.Domain.Entities.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Persistence.Configurations.Bookings
{
    public class BookingConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(b => b.Start)
            .ValueGeneratedOnAdd()
            .HasValueGenerator<DateTimeFormatGenerator>();
            builder.Property(b => b.End)
                .ValueGeneratedOnAdd()
                .HasValueGenerator<DateTimeFormatGenerator>();
        }
    }
}