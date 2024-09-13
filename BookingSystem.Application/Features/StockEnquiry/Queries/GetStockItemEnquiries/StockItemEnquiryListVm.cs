using BookingSystem.Application.Features.StockEnquiry.Queries.GetStockEnquiry;
using BookingSystem.Domain.Entities.Events;

namespace BookingSystem.Application.Features.StockEnquiry.Queries.GetStockItemEnquiries
{
    public class StockItemEnquiryListVm
    {

        public StockItemEnquiryListVm()
        {
        }
        public StockItemEnquiryListVm(Guid stockEnquiryId, Guid bookingId, bool ? isApproved )
        {
            StockEnquiryId = stockEnquiryId;
            BookingId = bookingId;
            AllApproved = isApproved ?? false;
        }
        public Guid StockEnquiryId { get; set; }
        public Guid BookingId { get; set; }
        public Event ? Booking { get; set; }
        public IEnumerable<StockItemEnquiryDto> ? StockItemEnquiries { get; set; }
        public bool AllApproved { get; set; }
    }
}