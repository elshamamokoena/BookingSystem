namespace BookingSystem.Shared.Models.Events
{
    public class LinkDto
    {
        public string Rel { get; set; } = string.Empty;
        public string Href { get; set; } = string.Empty;
        public string ElementId { get; set; } = string.Empty;

        public LinkDto() { }
        public LinkDto(string rel, string href, string elementId)
        {
            Rel = rel;
            Href = href;
            ElementId = elementId;
        }
    }
}