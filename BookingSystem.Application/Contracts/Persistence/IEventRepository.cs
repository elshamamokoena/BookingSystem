using BookingSystem.Application.Features.Events.Queries.GetEvents;
using BookingSystem.Application.ResourceParameters;
using BookingSystem.Domain.Entities.ConferenceRooms;
using BookingSystem.Domain.Entities.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Contracts.Persistence
{
    public interface IEventRepository : IAsyncRepository<Event> 
    {
        Task<IEnumerable<Event>> GetEventsAsync(GetEventsQuery bookingQuery);

    }
}
