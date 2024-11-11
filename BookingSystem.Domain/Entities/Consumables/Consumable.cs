using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Domain.Common;
using BookingSystem.Domain.Entities.ConferenceRooms;

namespace BookingSystem.Domain.Entities.Consumables
{
    public class Consumable : Auditable
    {
        public Guid ConsumableId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public bool IsVisible { get; set; }
        public Guid ConsumableCategoryId { get; set; }
        public ConsumableCategory Category { get; set; } = default!;
    }
}
