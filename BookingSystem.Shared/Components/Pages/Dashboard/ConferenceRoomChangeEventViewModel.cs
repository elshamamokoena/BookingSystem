using BookingSystem.Shared.Services;

namespace BookingSystem.Shared.Components.Pages.Dashboard
{
    public class ConferenceRoomChangeEventViewModel
    {
        public Guid ConferenceRoomChangeEventId { get; set; }
        public Guid ConferenceRoomId { get; set; }
        public ConferenceRoomForChangeEventDto? ConferenceRoom { get; set; }
        public string ChangeType { get; set; } = string.Empty;
        public int Amount { get; set; }
    }
}