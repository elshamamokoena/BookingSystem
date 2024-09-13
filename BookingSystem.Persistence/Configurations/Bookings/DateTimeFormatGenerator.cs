using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System.Runtime.Serialization;

namespace BookingSystem.Persistence.Configurations.Bookings
{
    public class DateTimeFormatGenerator:ValueGenerator<DateTimeFormat>
    {
        public override bool GeneratesTemporaryValues => false;

        public override DateTimeFormat Next(EntityEntry entry)
        {
            if (entry == null) throw new ArgumentNullException(nameof(entry));
            return new DateTimeFormat("yyyy/mm/dd HH:00");
        }
    }
}