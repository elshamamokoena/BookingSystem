using BookingSystem.Application.Contracts.Persistence;
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
        public async Task<IEnumerable<Booking>> GetBookingsAsync(GetBookingsQuery bookingsQuery)
        {
            ArgumentNullException.ThrowIfNull(bookingsQuery);
            var collection = _context.Bookings.AsQueryable();

            collection = collection
                .Where(x => x.EventId == bookingsQuery.EventId)
                .Include(x=>x.ConferenceRoom)
                .Include(x => x.Event);

            return await collection.ToListAsync();
        }
    }
}
