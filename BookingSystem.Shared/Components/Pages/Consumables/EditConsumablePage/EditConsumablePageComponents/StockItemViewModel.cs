using BookingSystem.Shared.Services;

namespace BookingSystem.Shared.Components.Pages.Consumables.EditConsumablePage.EditConsumablePageComponents
{
    public class StockItemViewModel
    {
        public Guid StockItemId { get; set; }
        public string Sku { get; set; } = string.Empty;
        public Guid ConsumableId { get; set; }
        public ConsumableDto Consumable { get; set; } = default!;
        public int Quantity { get; set; }
        public bool EnableStockManagement { get; set; }
    }
}