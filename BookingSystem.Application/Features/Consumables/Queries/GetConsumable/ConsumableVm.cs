using BookingSystem.Application.Features.Consumables.Queries.GetConsumables;

namespace BookingSystem.Application.Features.Consumables.Queries.GetConsumable
{
    public class ConsumableVm
    {
        public Guid ConsumableId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid ConsumableCategoryId { get; set; }
        public ConsumableCategoryDto ? Category {get;set;}
    }
}