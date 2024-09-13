namespace BookingSystem.Application.Features.Amenities.Commands.AddAmenityToRoom
{
    public class AmenityWithRoomDto
    {
        public Guid AmenityId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid ? ConferenceRoomId { get; set; }

        public bool IsAvailable { get; set; }

    }
}