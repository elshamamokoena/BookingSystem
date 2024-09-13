namespace BookingSystem.Application.Features.ConferenceRooms.Commands.UpdateConferenceRoom.UpdateConferenceRoom
{
    public class UpdatedConferenceRoomDto
    {
        public Guid ConferenceRoomId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; } 
    }
}