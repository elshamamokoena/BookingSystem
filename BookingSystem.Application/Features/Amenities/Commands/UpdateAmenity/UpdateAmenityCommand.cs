﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Amenities.Commands.UpdateAmenity
{
    public class UpdateAmenityCommand : IRequest<Unit>
    {
        public Guid AmenityId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid ConferenceRoomId { get; set; }
        public int Amount { get; set; }
        public bool IsAvailable { get; set; }
    }
}
