namespace BookingSystem.Application.Features.Consumables.Queries.GetConsumables
{
    public class ConsumableListCategoryDto
    {
        public Guid ConsumableCategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}