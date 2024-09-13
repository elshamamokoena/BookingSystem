using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<CreateEventCommandResponse>
    {
        public string Title { get; set; } = string.Empty;
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;

    }
}
