﻿using BookingSystem.Domain.Common;
using BookingSystem.Domain.Entities.Consumables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities.Inventory
{


    // ** stockitem contains ref to stock which contains ref to consumablecatregoy which is also in stockitem.
    public class StockItem: Auditable
    {
        public Guid StockItemId { get; set; }

        public string StockNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid StockId { get; set; } 
        public Stock Stock { get; set; } = default!;
        public Guid ? ConsumableId { get; set; } 
        public Consumable Consumable { get; set; }= default!;
        public int Quantity { get; set; }
    }
}