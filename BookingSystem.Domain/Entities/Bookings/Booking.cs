using BookingSystem.Domain.Common;
using BookingSystem.Domain.Entities.ConferenceRooms;
using BookingSystem.Domain.Entities.Events;
using BookingSystem.Domain.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities.Bookings
{
    public class Booking:Auditable
    {
        public Guid BookingId { get; set; }
       
        public Guid EventId { get; set; }
        public Event Event { get; set; } = default!;
        public Guid ConferenceRoomId { get; set; }
        public ConferenceRoom ConferenceRoom { get; set; } = default!;
        //public string Notes { get; set; } = string.Empty;   
        //public ICollection<StockEnquiry> EnquiryForStocks { get; set; }
        //= new List<StockEnquiry>();

    }
}
