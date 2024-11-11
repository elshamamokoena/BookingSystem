namespace BookingSystem.Application.Features.Amenities.Queries.GetAmenity
{
    public class ConferenceRoomDto
    {
        public Guid ConferenceRoomId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}