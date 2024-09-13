using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRooms;
using BookingSystem.Application.ResourceParameters;
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
    public class ConferenceRoomRepository : IConferenceRoomRepository
    {
        private readonly BookingSystemDbContext _context;

        public ConferenceRoomRepository(BookingSystemDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ConferenceRoomExistsAsync(Guid conferenceRoomId)
        {
            if(conferenceRoomId == Guid.Empty) throw new ArgumentNullException(nameof(conferenceRoomId));
            return await _context.ConferenceRooms.AnyAsync(c => c.ConferenceRoomId == conferenceRoomId);
        }

        public async Task<ConferenceRoom> AddConferenceRoom(ConferenceRoom conferenceRoom)
        {
            ArgumentNullException.ThrowIfNull(conferenceRoom, nameof(conferenceRoom));
            await _context.ConferenceRooms.AddAsync(conferenceRoom);
            return conferenceRoom;
        }

        public void DeleteConferenceRoom(ConferenceRoom conferenceRoom)
        {
            ArgumentNullException.ThrowIfNull(conferenceRoom, nameof(conferenceRoom));
            _context.ConferenceRooms.Remove(conferenceRoom);
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
        public async Task<ConferenceRoom> GetConferenceRoomAsync(Guid conferenceRoomId)
        {
            if(conferenceRoomId == Guid.Empty) throw new ArgumentNullException(nameof(conferenceRoomId));


#pragma warning disable CS8603 // Possible null reference return.
            return await _context.ConferenceRooms
                    .FirstOrDefaultAsync(c => c.ConferenceRoomId == conferenceRoomId);
#pragma warning restore CS8603 // Possible null reference return.
        }
        public async Task<IEnumerable<ConferenceRoom>> GetConferenceRoomsAsync(GetConferenceRoomsQuery resourceParameters)
        {
            ArgumentNullException.ThrowIfNull(resourceParameters, nameof(resourceParameters));

            //use collection to build up the query
            //IQueryable allows you to build up a query before it is executed
            var collection = _context.ConferenceRooms as IQueryable<ConferenceRoom>;
            var roomsToExclude = new List<ConferenceRoom>();


            if (!string.IsNullOrWhiteSpace(resourceParameters.SearchQuery))
            {

                var searchQuery = resourceParameters.SearchQuery.Trim();
                //Get all conference rooms that contain the search query in their name or tags
                //Combine the two collections into one
                collection = collection
                    .Where(c => c.Name.Contains(searchQuery))
                    .Union(collection
                    .Where(c=>c.Tags.Contains(searchQuery)));
            }

            //if (resourceParameters.StartTime.HasValue && resourceParameters.EndTime.HasValue)
            //{
            //     roomsToExclude = await _context.Events
            //      .Where(b => b.Start >= resourceParameters.StartTime && b.End <= resourceParameters.EndTime)
            //      .SelectMany(b => b.ConferenceRooms)
            //      .ToListAsync();
            //}
      
            // return the collection as a paged list
            return (await collection
                .ToListAsync())
                .Except(roomsToExclude) //exclude conference rooms that are already booked for the requested time
                .Skip(resourceParameters.PageSize * (resourceParameters.PageNumber - 1))
                .Take(resourceParameters.PageSize); 
        }
        public async Task<int> GetConferenceRoomsCountAsync()
        {
            return await _context.ConferenceRooms.CountAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public void UpdateConferenceRoom(ConferenceRoom conferenceRoom)
        {
            // Just hit saveasync after updating the conference room entity
            //it will automatically update the entity in the database
        }
    }
}
