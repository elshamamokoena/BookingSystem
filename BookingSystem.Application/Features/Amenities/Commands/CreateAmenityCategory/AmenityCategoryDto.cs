namespace BookingSystem.Application.Features.Amenities.Commands.CreateAmenityCategory
{
    public class AmenityCategoryDto
    {
        public Guid AmenityCategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}