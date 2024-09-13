namespace BookingSystem.Application.Features.Amenities.Commands.CreateAmenity
{
    public class AmenityDto
    {
        public Guid AmenityId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string AmenityCategoryName { get; set; } = string.Empty;
    }
}