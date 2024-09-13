﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand:IRequest<Unit>
    {
        public Guid EventId { get; set; }
    }
}
