using BookingSystem.Application.Features.StockEnquiry.Queries.GetStockEnquiry;
using BookingSystem.Application.Responses;

namespace BookingSystem.Application.Features.StockEnquiry.Commands.CreateStockItemEnquiry
{
    public class CreateStockItemEnquiryCommandResponse:BaseResponse
    {
        public CreateStockItemEnquiryCommandResponse():base()
        {
            Message = "Failed To Create Stock Item";
        }
        public StockItemEnquiryDto StockItemEnquiry { get;  set; }
    }
}