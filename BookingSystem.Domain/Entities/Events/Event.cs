﻿using BookingSystem.Domain.Common;
using BookingSystem.Domain.Entities.Bookings;
using BookingSystem.Domain.Entities.ConferenceRooms;
using BookingSystem.Domain.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities.Events
{
    public class Event : Auditable
    {
        public Guid EventId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
        public string Description { get; set; } = string.Empty;
        public ICollection<Booking> Bookings { get; set; }
            = new List<Booking>();

    }
}