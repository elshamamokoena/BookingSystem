using BookingSystem.Domain.Entities.Consumables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities.Inventory
{
    public class StockItemEnquiry
    {
        public Guid StockItemEnquiryId { get; set; }
        public Guid StockEnquiryId { get; set; }
        public StockEnquiry StockEnquiry { get; set; } = default!;
        public Guid ConsumableId { get; set; }
        public int Quantity { get; set; }
        public bool IsApproved { get; set; } = false;

    }
}
