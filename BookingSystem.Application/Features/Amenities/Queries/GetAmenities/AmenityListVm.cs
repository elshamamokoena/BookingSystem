using BookingSystem.Application.Features.Amenities.Commands.CreateAmenityCategory;

namespace BookingSystem.Application.Features.Amenities.Queries.GetAmenities
{
    public class AmenityListVm
    {
        public Guid AmenityId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public Guid AmenityCategoryId { get; set; }
        public AmenityCategoryDto? AmenityCategory { get; set; }
        public bool IsAvailable { get; set; }
        public int Amount { get; set; }
    }
}