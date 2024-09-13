using BookingSystem.Application.Responses;

namespace BookingSystem.Application.Features.ConferenceRooms.Commands.UpdateConferenceRoom.UpdateConferenceRoom
{
    public class UpdateConferenceRoomCommandResponse : BaseResponse
    {
        public UpdateConferenceRoomCommandResponse() : base()
        {
        }
        public UpdatedConferenceRoomDto ConferenceRoom { get; set; }
    }
}