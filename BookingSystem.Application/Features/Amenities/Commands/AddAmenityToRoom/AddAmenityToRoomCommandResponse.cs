using BookingSystem.Application.Responses;

namespace BookingSystem.Application.Features.Amenities.Commands.AddAmenityToRoom
{
    public class AddAmenityToRoomCommandResponse:BaseResponse
    {
        public AddAmenityToRoomCommandResponse():base()
        {

        }

        public AmenityWithRoomDto Amenity { get; internal set; }
    }
}