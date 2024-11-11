namespace BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRoom
{
    public class AmenityDto
    {
        public Guid AmenityId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid AmenityCategoryId { get; set; }
        public bool IsAvailable { get; set; }
    }
}