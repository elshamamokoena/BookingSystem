﻿using BookingSystem.Application.Features.Amenities.Commands.CreateAmenity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRoom
{
    public class ConferenceRoomVm
    {
        public Guid ConferenceRoomId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Tags { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }

        public string Status { get; set; } = string.Empty;
        public ICollection<AmenityDto>? Amenities { get; set; }
        public ICollection<BookingDto>? Bookings { get; set; }
    }
}
