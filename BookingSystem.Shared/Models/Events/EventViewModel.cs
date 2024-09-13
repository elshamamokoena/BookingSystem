using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Models.Events
{
    public class EventViewModel
    {
        public Guid EventId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Location { get; set; } = "Room1";

        public string Organizer { get; set; } = "John Doe";
        public IEnumerable<LinkDto> Links { get {
                return [new LinkDto("edit_event", $"edit-event?eventid={EventId}", "edit-event"),
                        new LinkDto("get_event", $"event-detail?eventid={EventId}","get-event")]; 
            }
        }
     
        
        public string ClassNames => Status switch
        {
            "Pending" => "bg-soft-primary",
            "Confirmed" => "bg-soft-success",
            "Cancelled" => "bg-soft-danger",
            _ => "bg-soft-warning"
        };
    }
}
