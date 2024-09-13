using BookingSystem.Application.Responses;

namespace BookingSystem.Application.Features.Amenities.Commands.CreateAmenityCategory
{
    public class CreateAmenityCategoryCommandResponse : BaseResponse
    {
        public CreateAmenityCategoryCommandResponse() { }
        public AmenityCategoryDto AmenityCategory { get; set; }
    }
}