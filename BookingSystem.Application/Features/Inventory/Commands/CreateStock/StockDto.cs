namespace BookingSystem.Application.Features.Inventory.Commands.CreateStock
{
    public class StockDto
    {
        public Guid StockId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}