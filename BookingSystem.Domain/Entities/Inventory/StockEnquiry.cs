using BookingSystem.Domain.Entities.Consumables;
using BookingSystem.Domain.Entities.Events;
using BookingSystem.Domain.Entities.Bookings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Domain.Common;

namespace BookingSystem.Domain.Entities.Inventory
{
    public class StockEnquiry:Auditable
    {
        public Guid StockEnquiryId { get; set; }
        public Guid BookingId { get; set; }
        public Booking Booking { get; set; } = default!;
        public ICollection<StockItemEnquiry> StockItemEnquiries { get; set; }
            = new List<StockItemEnquiry>();
        public bool IsApproved { get; set; } = false;
    }
}
