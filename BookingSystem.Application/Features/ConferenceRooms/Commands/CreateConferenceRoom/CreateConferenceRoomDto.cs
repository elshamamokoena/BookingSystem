namespace BookingSystem.Application.Features.ConferenceRooms.Commands.CreateConferenceRoom
{
    public class CreateConferenceRoomDto
    {
        public Guid ConferenceRoomId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
    }
}