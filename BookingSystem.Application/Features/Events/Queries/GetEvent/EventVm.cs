namespace BookingSystem.Application.Features.Events.Queries.GetEvent
{
    public class EventVm
    {
        public Guid EventId { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Label { get; set; } = string.Empty;
    }
}