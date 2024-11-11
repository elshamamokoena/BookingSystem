using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Bookings
{
    public class UpdateBookingViewModel
    {
        public Guid BookingId { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
