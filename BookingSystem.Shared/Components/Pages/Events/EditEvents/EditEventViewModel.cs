using BookingSystem.Shared.Components.Pages.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Events.EditEvents
{
    public class EditEventViewModel
    {
        public Guid EventId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage ="The title of the conference should be 50 characters or less")]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Label { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "The description of the conference should be 100 characters or less")]
        public string Description { get; set; } = string.Empty;
        public DateTimeOffset Start { get; set; } 
        public DateTimeOffset End { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        public CategoryViewModel Category { get; set; } = default!;
    }
}
