using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Models
{
    public class DetailedBookingVm
    {
        public Guid BookingId { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Notes { get; set; } = string.Empty;
        public IEnumerable<StockEnquiryDto> EnquiryForStocks { get; set; }

    }
}
