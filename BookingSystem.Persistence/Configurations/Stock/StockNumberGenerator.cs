using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Persistence.Configurations.Stock
{
    public class StockNumberGenerator: ValueGenerator<string>
    {
        public override bool GeneratesTemporaryValues { get; }

        public override string Next(EntityEntry entity)
        {
            if(entity==null) throw new ArgumentNullException(nameof(entity));
            return GenerateStockNumber();
        }

        private string GenerateStockNumber()
        {
          
            return Guid.NewGuid().ToString();
        }
    }
}
