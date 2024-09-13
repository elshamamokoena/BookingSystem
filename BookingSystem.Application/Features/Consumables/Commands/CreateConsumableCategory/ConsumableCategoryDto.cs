namespace BookingSystem.Application.Features.Consumables.Commands.CreateConsumableCategory
{
    public class ConsumableCategoryDto
    {
        public Guid ConsumableCategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int AmountOfConsumables { get; set; }

    }
}