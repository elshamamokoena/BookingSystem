using BookingSystem.Domain.Entities.Events;

namespace BookingSystem.Application.Features.StockEnquiry.Queries.GetStockEnquiry
{
    public class StockEnquiryVm
    {
        public Guid StockEnquiryId { get; set; }
        public Guid BookingId { get; set; }
        public Event ? Booking { get; set; }
        public IEnumerable<StockItemEnquiryDto> ? StockItemEnquiries { get; set; }
        public bool IsApproved { get; set; }

    }
}