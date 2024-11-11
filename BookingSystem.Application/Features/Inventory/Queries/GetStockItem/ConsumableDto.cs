namespace BookingSystem.Application.Features.Inventory.Queries.GetStockItem
{
    public class ConsumableDto
    {
        public Guid ConsumableId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

    }
}