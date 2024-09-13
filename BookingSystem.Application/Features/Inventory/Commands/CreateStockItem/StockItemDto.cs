namespace BookingSystem.Application.Features.Inventory.Commands.CreateStockItem
{
    public class StockItemDto
    {
        public Guid StockItemId { get; set; }

        public string StockNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid StockId { get; set; }
        public Guid? ConsumableId { get; set; }
        public int Quantity { get; set; }
    }
}