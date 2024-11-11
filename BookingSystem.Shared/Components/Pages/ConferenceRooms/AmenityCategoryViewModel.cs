namespace BookingSystem.Shared.Components.Pages.ConferenceRooms
{
    public class AmenityCategoryViewModel
    {
        public Guid AmenityCategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
    }
}