using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.ClassLibrary;
using BookingSystem.Domain.Common;
using BookingSystem.Domain.Entities.Amenities;
using BookingSystem.Domain.Entities.Bookings;
using BookingSystem.Domain.Entities.Consumables;

namespace BookingSystem.Domain.Entities.ConferenceRooms
{
    public  class ConferenceRoom : Auditable
    {
        public Guid ConferenceRoomId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; } 
        public string Description { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        //only unavailable if currently in use
        public bool IsAvailable { get; set; }
        public string Status { get; set; } = string.Empty;
          //= nameof(ConferenceRoomStatus.VacantAndNotBooked);

        public ICollection<Booking> Bookings { get; set; }
            = new List<Booking>();

        public ICollection<Amenity> Amenities { get; set; }
            = new List<Amenity>();

    }
    //public partial class ConferenceRoom
    //{
    //    // Amenities
    //    public bool HasVideoConferencing { get; set; }
    //    public bool HasWiFi { get; set; }
    //    public bool HasComfortableSeating { get; set; }
    //    public bool HasDigitalProjectors { get; set; }
    //    public bool HasAudioEquipment { get; set; }
    //    public bool HasWhiteboards { get; set; }
    //    public bool HasCatering { get; set; }
    //    public bool HasEasels { get; set; }
    //    public bool HasHandicapAccess { get; set; }
    //    public bool HasAirConditioning { get; set; }
    //    public bool HasNaturalLight { get; set; }
    //    public bool HasPhoneConferencing { get; set; }
    //    public bool HasCoffeeTea { get; set; }
    //    public bool HasKitchenette { get; set; }
    //    public bool HasBreakoutRooms { get; set; }
    //    public bool HasPodium { get; set; }
    //}
}
