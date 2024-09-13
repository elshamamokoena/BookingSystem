namespace BookingSystem.Application.Features.StockEnquiry.Queries.GetStockEnquiries
{
    public class StockEnquiryListVm
    {
        public StockEnquiryListVm(IEnumerable<ForListStockEnquiryDto> stockEnquiries)
        {
            StockEnquiries = stockEnquiries;
        }
        public IEnumerable<ForListStockEnquiryDto> StockEnquiries { get; set; }

    }
}