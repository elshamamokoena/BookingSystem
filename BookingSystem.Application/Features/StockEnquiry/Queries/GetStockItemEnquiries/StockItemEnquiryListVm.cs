using BookingSystem.Application.Features.StockEnquiry.Queries.GetStockEnquiry;
using BookingSystem.Domain.Entities.Events;

namespace BookingSystem.Application.Features.StockEnquiry.Queries.GetStockItemEnquiries
{
    public class StockItemEnquiryListVm
    {
        public Guid StockItemEnquiryId { get; set; }
        public Guid StockEnquiryId { get; set; }
        public Guid ConsumableId { get; set; }
        public int Quantity { get; set; }
        public bool IsApproved { get; set; } = false;

        //public StockItemEnquiryListVm()
        //{
        //}
        //public StockItemEnquiryListVm(Guid stockEnquiryId, Guid bookingId, bool ? isApproved )
        //{
        //    StockEnquiryId = stockEnquiryId;
        //    BookingId = bookingId;
        //    AllApproved = isApproved ?? false;
        //}
        //public Guid StockEnquiryId { get; set; }
        //public Guid BookingId { get; set; }
        //public Event ? Booking { get; set; }
        //public IEnumerable<StockItemEnquiryDto> ? StockItemEnquiries { get; set; }
        //public bool AllApproved { get; set; }
    }
}