using BookingSystem.Application.Responses;

namespace BookingSystem.Application.Features.Consumables.Commands.CreateConsumableCategory
{
    public class CreateConsumableCategoryCommandResponse:BaseResponse
    {
        public CreateConsumableCategoryCommandResponse():base()
        {

        }
        public ConsumableCategoryDto ConsumableCategory { get; set; }
    }
}