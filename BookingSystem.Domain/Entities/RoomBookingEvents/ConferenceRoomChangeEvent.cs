using BookingSystem.Domain.Common;
using BookingSystem.Domain.Entities.ConferenceRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities.RoomBookingEvents
{
    public class ConferenceRoomChangeEvent:Auditable
    {
        public Guid ConferenceRoomChangeEventId { get; set; }
        public Guid ConferenceRoomId { get; set; }
        public ConferenceRoom? ConferenceRoom { get; set; }
        public int Amount { get; set; }
        public string ChangeType { get; set; } = nameof(ChangeEventType.Created);
    }
}
