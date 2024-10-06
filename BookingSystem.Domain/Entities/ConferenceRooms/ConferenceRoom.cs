using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Domain.Common;
using BookingSystem.Domain.Entities.Amenities;
using BookingSystem.Domain.Entities.Bookings;
using BookingSystem.Domain.Entities.Consumables;

namespace BookingSystem.Domain.Entities.ConferenceRooms
{
    public class ConferenceRoom : Auditable
    {
        public Guid ConferenceRoomId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; } 
        public string Description { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        //only unavailable if currently in use
        public bool IsAvailable { get; set; } = true;

        public ICollection<Booking> Bookings { get; set; }
            = new List<Booking>();

        //public ICollection<Amenity> Amenities { get; set; }
        //    = new List<Amenity>();

    }
}
