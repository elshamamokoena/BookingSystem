namespace BookingSystem.Application.Features.Amenities.Queries.GetAmenityCategories
{
    public class AmenityCategoryListVm
    {
        public Guid AmenityCategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}