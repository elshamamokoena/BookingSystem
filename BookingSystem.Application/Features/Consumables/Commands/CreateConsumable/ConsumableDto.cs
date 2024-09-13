namespace BookingSystem.Application.Features.Consumables.Commands.CreateConsumable
{
    public class ConsumableDto
    {
        public Guid ConsumableId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid ConsumableCategoryId { get; set; }
    }
}