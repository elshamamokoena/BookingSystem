using BookingSystem.Domain.Common;
using BookingSystem.Domain.Entities.ConferenceRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities.Amenities
{
    public class Amenity: Auditable
    {
        public Guid AmenityId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid AmenityCategoryId { get; set; }
        public AmenityCategory? AmenityCategory { get; set; }
        public Guid ? ConferenceRoomId { get; set; }
        public ConferenceRoom? ConferenceRoom { get; set; }
        public int Amount { get; set; }
        public bool IsAvailable { get; set; }

    }
}
