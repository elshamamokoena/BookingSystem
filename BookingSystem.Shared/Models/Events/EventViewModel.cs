using BookingSystem.Shared.Components.Pages.Categories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Models.Events
{
    public partial class EventViewModel
    {
        public Guid EventId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The title of the conference should be 50 characters or less")]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Label { get; set; } = string.Empty;

        [Required]
        [StringLength(100, ErrorMessage = "The description of the conference should be 100 characters or less")]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        public string Status { get; set; } = string.Empty;
        [Required]
        public Guid CategoryId { get; set; }
        public CategoryViewModel Category { get; set; } = default!;
    }

    public partial class EventViewModel
    {
        public string Location { get; set; } = "Room1";
        public string Organizer { get; set; } = "John Doe";
        public IEnumerable<LinkDto> Links
        {
            get
            {
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
