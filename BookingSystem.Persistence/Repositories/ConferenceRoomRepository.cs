using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRoom;
using BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRooms;
using BookingSystem.ClassLibrary;
using BookingSystem.Domain.Entities.ConferenceRooms;
using BookingSystem.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Persistence.Repositories
{
    public class ConferenceRoomRepository :BaseRepository<ConferenceRoom>, IConferenceRoomRepository
    {

        public ConferenceRoomRepository(BookingSystemDbContext context): base(context)
        {
        }

        public async Task<bool> ConferenceRoomExistsAsync(Guid conferenceRoomId)
        {
            if(conferenceRoomId == Guid.Empty) throw new ArgumentNullException(nameof(conferenceRoomId));
            return await _context.ConferenceRooms.AnyAsync(c => c.ConferenceRoomId == conferenceRoomId);
        }




        //public async Task<IEnumerable<ConferenceRoom>> GetAvailableConferenceRoomsAsync(DateTime startTime, DateTime endTime)
        //{
        //    //Get all bookings that overlap with the requested time
        //    var bookings = await _context.Bookings
        //        .Where(b => b.StartTime >= startTime && b.EndTime <= endTime)
        //        .Include(b => b.ConferenceRooms)
        //        .ToListAsync();

        //    //Get available conference rooms
        //    return await _context.ConferenceRooms
        //                .Except(bookings.SelectMany(b => b.ConferenceRooms)) //exclude conference rooms that are already booked for the requested time
        //                .ToListAsync();
        //}
        public async Task<ConferenceRoom> GetConferenceRoomAsync(GetConferenceRoomQuery query)
        {
            if(query.ConferenceRoomId == Guid.Empty) throw new ArgumentNullException(nameof(query.ConferenceRoomId));

            var room = _context.ConferenceRooms.AsQueryable();

            if (query.IncludeBookings.HasValue && query.IncludeBookings.Value)
                room = room.Include(r => r.Bookings);

            if (query.IncludeAmenities.HasValue && query.IncludeAmenities.Value)
                room = room.Include(r => r.Amenities);

#pragma warning disable CS8603 // Possible null reference return.
            return await room
                    .FirstOrDefaultAsync(c => c.ConferenceRoomId == query.ConferenceRoomId);
#pragma warning restore CS8603 // Possible null reference return.
        }
        public async Task<PagedList<ConferenceRoom>> GetConferenceRoomsAsync(GetConferenceRoomsQuery query)
        {
            ArgumentNullException.ThrowIfNull(nameof(GetConferenceRoomsQuery), nameof(query) );
            //use collection to build up the query
            //IQueryable allows you to build up a query before it is executed
            var collection = _context.ConferenceRooms as IQueryable<ConferenceRoom>;

            if (!string.IsNullOrWhiteSpace(query.SearchQuery))
            {
                var searchQuery = query.SearchQuery.Trim();
                //Get all conference rooms that contain the search query in their name or tags
                //Combine the two collections into one
                collection = collection
                    .Where(c => c.Name.Contains(searchQuery))
                    .Union(collection
                    .Where(c=>c.Tags.Contains(searchQuery)))
                    .Union(collection
                    .Where(c=>c.Description.Contains(searchQuery)))
                    .Union(collection
                    .Where(c=>c.Status.Contains(searchQuery)))
                    .Union(collection
                    .Where(c=>c.Capacity.ToString().Contains(searchQuery)));
            }
            var count = await collection.CountAsync();
            var list = await collection
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .OrderBy(c=>c.Name)
                .ToListAsync();
            return new PagedList<ConferenceRoom>(list, count , query.PageNumber, query.PageSize);
        }
        public async Task<int> GetConferenceRoomsCountAsync()
        {
            return await _context.ConferenceRooms.CountAsync();
        }

        public async Task<bool> IsAvableForBooking(DateTime starttime, DateTime endTime, Guid roomId)
        {
            return await _context.ConferenceRooms
                .AnyAsync(c => c.ConferenceRoomId == roomId && c.Bookings.All(b => b.Event.End < starttime || b.Event.Start > endTime));
        }

   
        public void UpdateConferenceRoom(ConferenceRoom conferenceRoom)
        {
            // Just hit saveasync after updating the conference room entity
            //it will automatically update the entity in the database
        }
    }
}
