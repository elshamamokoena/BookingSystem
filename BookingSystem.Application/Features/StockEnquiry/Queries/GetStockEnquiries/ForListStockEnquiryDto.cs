namespace BookingSystem.Application.Features.StockEnquiry.Queries.GetStockEnquiries
{
    public class ForListStockEnquiryDto
    {
        public Guid StockEnquiryId { get; set; }
        public Guid BookingId { get; set; }
        public bool IsApproved { get; set; }
    }
}