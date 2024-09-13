using BookingSystem.Domain.Common;
using BookingSystem.Domain.Entities.Consumables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities.Inventory
{
    public class Stock: Auditable
    {
        public Guid StockId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<StockItem> StockItems { get; set; }
            = new List<StockItem>();
    }
}
