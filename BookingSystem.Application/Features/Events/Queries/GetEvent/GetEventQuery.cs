using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Events.Queries.GetEvent
{
    public class GetEventQuery : IRequest<EventVm>
    {
        public Guid EventId { get; set; }
    }
}
