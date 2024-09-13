namespace BookingSystem.Application.Features.StockEnquiry.Commands.CreateStockEnquiry
{
    public class StockEnquiryDto
    {
        public Guid StockEnquiryId { get; set; }
        public Guid BookingId { get; set; }
        public bool IsApproved { get; set; } 

    }
}