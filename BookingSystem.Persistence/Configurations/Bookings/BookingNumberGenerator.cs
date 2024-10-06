using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Persistence.Configurations.Bookings
{
    public class BookingNumberGenerator : ValueGenerator<string>
    {
        public override bool GeneratesTemporaryValues => throw new NotImplementedException();

        public override string Next(EntityEntry entry)
        {
            if (entry == null) throw new ArgumentNullException(nameof(entry));
            return $"#";
        }
    }
}
