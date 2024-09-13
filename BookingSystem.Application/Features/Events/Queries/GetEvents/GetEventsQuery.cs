using BookingSystem.Application.Features.Events.Queries.GetEvent;
using BookingSystem.Application.ResourceParameters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Events.Queries.GetEvents
{
    public class GetEventsQuery : ResourceParameterBase, IRequest<IEnumerable<EventVm>>
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}
