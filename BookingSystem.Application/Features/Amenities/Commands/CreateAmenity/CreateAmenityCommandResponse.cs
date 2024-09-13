using BookingSystem.Application.Responses;

namespace BookingSystem.Application.Features.Amenities.Commands.CreateAmenity
{
    public class CreateAmenityCommandResponse:BaseResponse
    {

        public CreateAmenityCommandResponse():base()
        {
        }
        public AmenityDto Amenity { get; set; }
    }
}