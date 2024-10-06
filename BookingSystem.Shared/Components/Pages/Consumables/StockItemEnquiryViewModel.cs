namespace BookingSystem.Shared.Components.Pages.Consumables
{
    public class StockItemEnquiryViewModel
    {

        public Guid StockItemEnquiryId { get; set; }
        public Guid StockEnquiryId { get; set; }
        public Guid ConsumableId { get; set; }
        public int Quantity { get; set; }
        public bool IsApproved { get; set; } = false;
    }
}