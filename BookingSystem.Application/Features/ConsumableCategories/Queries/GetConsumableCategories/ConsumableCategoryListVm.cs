namespace BookingSystem.Application.Features.ConsumableCategories.Queries.GetConsumableCategories
{
    public class ConsumableCategoryListVm
    {
        public Guid ConsumableCategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}