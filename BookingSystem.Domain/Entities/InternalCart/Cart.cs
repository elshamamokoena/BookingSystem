﻿using BookingSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities.InternalCart
{
    public class Cart:Auditable
    {
        public Guid CartId { get; set; }
        public Guid UserId { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
            = new List<CartItem>();
    }
}