﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities.Bookings
{
    public enum BookingStatus
    {
        Pending,
        Reserved,
        Cancelled,
        Approved,
    }
}
