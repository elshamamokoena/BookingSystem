using BookingSystem.Application.Responses;

namespace BookingSystem.Application.Features.StockEnquiry.Commands.CreateStockEnquiry
{
    public class CreateStockEnquiryCommandResponse : BaseResponse
    {
        public CreateStockEnquiryCommandResponse() : base()
        {

        }
        public StockEnquiryDto StockEnquiry { get; set; }
    }
}