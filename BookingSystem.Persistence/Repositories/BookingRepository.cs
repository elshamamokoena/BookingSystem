using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Features.Bookings.Queries.GetBooking;
using BookingSystem.Application.Features.Bookings.Queries.GetBookings;
using BookingSystem.Domain.Entities.Bookings;
using BookingSystem.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Persistence.Repositories
{
    public class BookingRepository :BaseRepository<Booking>, IBookingRepository
    {

        public BookingRepository(BookingSystemDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Booking> GetBookingAsync(GetBookingQuery query)
        {
            var booking = _context.Bookings as IQueryable<Booking>;

            if (query.IncludeEvent.HasValue && query.IncludeEvent.Value)
                booking = booking.Include(x => x.Event);

            if (query.IncludeRoom.HasValue && query.IncludeRoom.Value)
                booking = booking.Include(x => x.ConferenceRoom);

#pragma warning disable CS8603 // Possible null reference return.
            return await booking
                .FirstOrDefaultAsync(x => x.BookingId == query.BookingId);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<IEnumerable<Booking>> GetBookingsAsync(GetBookingsQuery query)
        {
            ArgumentNullException.ThrowIfNull(query);
            var collection = _context.Bookings.AsQueryable();

            collection = collection
                .Where(x => x.EventId == query.EventId)
                .Include(x=>x.ConferenceRoom)
                .Include(x => x.Event);

            return await collection
                .OrderBy(x => x.BookingNumber)
                .Skip(query.PageSize * (query.PageNumber-1))
                .Take(query.PageSize)
                .ToListAsync();
        }

        public async Task<bool> IsBookingConflict(DateTime ? startDate, DateTime ?endDate, Guid conferenceRoomId)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (!startDate.HasValue || !endDate.HasValue)
                return (await _context.ConferenceRooms.FirstOrDefaultAsync(r => r.ConferenceRoomId == conferenceRoomId)).IsAvailable;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            return await _context.Bookings
                .AnyAsync(x => x.ConferenceRoomId == conferenceRoomId &&
                               x.Event.End <= endDate && 
                               x.Event.Start >= startDate);
        }
    }
}
