using BookingSystem.Application.Responses;

namespace BookingSystem.Application.Features.Consumables.Commands.CreateConsumable
{
    public class CreateConsumableCommandResponse:BaseResponse
    {
        public CreateConsumableCommandResponse():base()
        {

        }
        public ConsumableDto Consumable { get; set; }
    }
}