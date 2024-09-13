using BookingSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities.Consumables
{
    public class ConsumableCategory: Auditable
    {
        public Guid ConsumableCategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Consumable> Consumables { get; set; }
            = new List<Consumable>();
        public int AmountOfConsumables { get; set; }
    }
}
