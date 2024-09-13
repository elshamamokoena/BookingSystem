using BookingSystem.Application.Responses;

namespace BookingSystem.Application.Features.Inventory.Commands.CreateStock
{
    public class CreateStockCommandResponse:BaseResponse
    {
        public CreateStockCommandResponse():base()
        {

        }
        public StockDto Stock { get; set; }
    }
}