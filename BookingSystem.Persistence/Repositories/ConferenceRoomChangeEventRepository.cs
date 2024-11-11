using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Features.RoomBookingEvents.Queries.GetRoomBookingEvents;
using BookingSystem.ClassLibrary;
using BookingSystem.Domain.Entities.RoomBookingEvents;
using BookingSystem.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Persistence.Repositories
{
    public class ConferenceRoomChangeEventRepository : BaseRepository<ConferenceRoomChangeEvent>, IConferenceRoomChangeEventRepository
    {
        private readonly IMapper _mapper;
        public ConferenceRoomChangeEventRepository(BookingSystemDbContext context, IMapper mapper)
            : base(context)
        {
            _mapper = mapper;
        }

        public async Task<ConferenceRoomChangeEvent> AddOrUpdateRoomBookingEventAsync(Guid conferenceRoomId)
        {

            var roomBookingEvent = await _context.ConferenceRoomChangeEvents
                .FirstOrDefaultAsync(x => x.ConferenceRoomId == conferenceRoomId);

            if (roomBookingEvent != null)
            {
                roomBookingEvent.Amount++;
                //roomBookingEvent.ChangeType = nameof(ChangeEventType.Updated);
                _context.ConferenceRoomChangeEvents.Update(roomBookingEvent);
            }
            else
            {
                roomBookingEvent = new ConferenceRoomChangeEvent
                {
                    ConferenceRoomId = conferenceRoomId,
                    Amount = 1,
                    ChangeType = nameof(ChangeEventType.Created)
                };
                await _context.ConferenceRoomChangeEvents.AddAsync(roomBookingEvent);
            }
            return roomBookingEvent;
        }

  

        public async Task<PagedList<ConferenceRoomChangeEvent>> GetConferenceRoomChangeEventsAsync(GetConferenceRoomChangeEventsQuery query)
        {
            ArgumentNullException.ThrowIfNull(nameof(GetConferenceRoomChangeEventsQuery), nameof(query));
            var collection = _context.ConferenceRoomChangeEvents as IQueryable<ConferenceRoomChangeEvent>;

            if(query.ConferenceRoomId.HasValue)
                collection = collection
                    .Where(x => x.ConferenceRoomId == query.ConferenceRoomId.Value);

            if(!string.IsNullOrWhiteSpace(query.ChangeEventType))
                collection = collection.Where(x => x.ChangeType == query.ChangeEventType);

            if(query.IncludeConferenceRoom.HasValue && query.IncludeConferenceRoom.Value)
                collection = collection.Include(x => x.ConferenceRoom);

            var count = await collection.CountAsync();

            var list = await collection
                .OrderByDescending(r=>r.Amount)
                .ToListAsync();

            return new PagedList<ConferenceRoomChangeEvent>
                (list,count, query.PageNumber,query.PageSize);
        }





    }
}
