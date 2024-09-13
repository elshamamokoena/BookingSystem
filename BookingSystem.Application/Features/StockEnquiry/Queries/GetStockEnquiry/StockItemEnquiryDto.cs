namespace BookingSystem.Application.Features.StockEnquiry.Queries.GetStockEnquiry
{
    public class StockItemEnquiryDto
    {
        public Guid StockItemEnquiryId { get; set; }
        public Guid StockEnquiryId { get; set; }
        public Guid ConsumableId { get; set; }
        public int Quantity { get; set; }
        public bool IsApproved { get; set; }
    }
}