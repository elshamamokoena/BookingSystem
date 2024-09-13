using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Features.Events.Queries.GetEvents;
using BookingSystem.Application.ResourceParameters;
using BookingSystem.Domain.Entities.ConferenceRooms;
using BookingSystem.Domain.Entities.Events;
using BookingSystem.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Persistence.Repositories
{
    public class EventRepository :BaseRepository<Event> ,IEventRepository
    {
        public EventRepository(BookingSystemDbContext context): base(context)
        {
        }
        public async Task<Event> AddEventAsync(Event @event)
        {
            ArgumentNullException.ThrowIfNull(@event, nameof(@event));
            await _context.Events.AddAsync(@event);
            return @event;
        }

        public void DeleteEventAsync(Event eventToDelete)
        {
            ArgumentNullException.ThrowIfNull(eventToDelete, nameof(eventToDelete));
            _context.Events.Remove(eventToDelete);
        }

        public async Task<bool> EventExistsAsync(Guid bookingId)
        {
            return await _context.Events
                .AnyAsync(b => b.EventId == bookingId);
        }

        public async Task<Event> GetEventAsync(Guid eventId)
        {
            if (eventId == Guid.Empty) throw new ArgumentNullException(nameof(eventId));

            #pragma warning disable CS8603 // Possible null reference return.
            return await _context.Events
                .FirstOrDefaultAsync(b => b.EventId == eventId);
            #pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<IEnumerable<Event>> GetEventsAsync(GetEventsQuery resourceParamaters)
        {
            ArgumentNullException.ThrowIfNull(resourceParamaters, nameof(resourceParamaters));

            var collection = _context.Events as IQueryable<Event>;

            if(resourceParamaters.Start.HasValue)
                collection = collection.Where(b => b.Start >= resourceParamaters.Start);

            if(resourceParamaters.End.HasValue)
                collection = collection.Where(b => b.End <= resourceParamaters.End);

            return await collection
                .OrderBy(b => b.Start)
                .Skip((resourceParamaters.PageNumber - 1) * resourceParamaters.PageSize)
                .Take(resourceParamaters.PageSize)
                .ToListAsync();
        }



        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateEventAsync(Event @event)
        {
           // 
        }
    }
}
