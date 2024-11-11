using BookingSystem.Shared.Services;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Shared.Components.Pages.ConferenceRooms
{
    public class AmenityViewModel
    {
        public Guid AmenityId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]

        public string Description { get; set; } = string.Empty;
        public Guid ConferenceRoomId { get; set; }
        [Required]
        public Guid AmenityCategoryId { get; set; }

        public AmenityCategoryDto ? AmenityCategory { get; set; }
        public int Amount { get; set; }

        public bool IsAvailable { get; set; }

    }
}