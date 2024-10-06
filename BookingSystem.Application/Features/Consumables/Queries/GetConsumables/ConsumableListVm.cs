using BookingSystem.Application.Features.Consumables.Commands.CreateConsumableCategory;

namespace BookingSystem.Application.Features.Consumables.Queries.GetConsumables
{
    public class ConsumableListVm
    {
        public Guid ConsumableId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid ConsumableCategoryId { get; set; }
        public ConsumableCategoryForListDto Category { get; set; } = default!;

    }
}