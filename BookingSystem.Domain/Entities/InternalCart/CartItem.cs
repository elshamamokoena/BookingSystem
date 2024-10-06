using BookingSystem.Domain.Common;
using BookingSystem.Domain.Entities.Consumables;

namespace BookingSystem.Domain.Entities.InternalCart
{
    public class CartItem:Auditable
    {
        public Guid CartItemId { get; set; }
        public Guid CartId { get; set; }
        public Cart Cart { get; set; } = default!;
        public Guid ConsumableId { get; set; }
        public Consumable Consumable { get; set; } = default!;
        public int Quantity { get; set; }
    }
}