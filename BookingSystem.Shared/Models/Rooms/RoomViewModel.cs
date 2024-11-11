using BookingSystem.Shared.Models.Events;
using BookingSystem.Shared.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Models.Rooms
{
    public class RoomViewModel
    {

        public Guid ConferenceRoomId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Capacity is required")]
        public int Capacity { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;

        public string Tags { get; set; } = string.Empty;

        public bool IsAvailable { get; set; }
        public ICollection<BookingDto> Bookings { get; set; } 
            = new List<BookingDto>();
        public ICollection<AmenityDto> Amenities { get; set; }
            = new List<AmenityDto>();
        public string Status {  get; set; } = string.Empty ;
        public string ClassName => IsAvailable ? "bg-soft-success" : "bg-soft-warning";

        public List<LinkDto> Links => [new LinkDto("get",$"room-detail/{ConferenceRoomId}","room-detail")];
    }
}
