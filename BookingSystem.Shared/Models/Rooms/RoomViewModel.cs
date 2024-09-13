using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Models.Rooms
{
    public class RoomViewModel
    {

        public Guid ConferenceRoomId { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Capacity { get; set; }

        public string Description { get; set; } = string.Empty;

        public string Tags { get; set; } = string.Empty;

        public bool IsAvailable { get; set; }

        public string Status => IsAvailable ? "Available" : "Unavailable";
        public string ClassName => IsAvailable ? "bg-soft-success" : "bg-soft-warning";
    }
}
