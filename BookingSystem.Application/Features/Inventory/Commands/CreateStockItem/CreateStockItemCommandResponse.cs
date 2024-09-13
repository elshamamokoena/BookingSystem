using BookingSystem.Application.Responses;

namespace BookingSystem.Application.Features.Inventory.Commands.CreateStockItem
{
    public class CreateStockItemCommandResponse:BaseResponse
    {
        public CreateStockItemCommandResponse():base()
        {

        }
        public StockItemDto StockItem { get; set; }
    }
}