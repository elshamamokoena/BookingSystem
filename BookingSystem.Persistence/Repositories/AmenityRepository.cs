using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Features.Amenities.Queries.GetAmenities;
using BookingSystem.Application.Features.Amenities.Queries.GetAmenity;
using BookingSystem.Domain.Entities.Amenities;
using BookingSystem.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Persistence.Repositories
{
    public class AmenityRepository :BaseRepository<Amenity>, IAmenityRepository
    {
        public AmenityRepository(BookingSystemDbContext context): base(context)
        {
        }

        public async Task<IEnumerable<Amenity>> GetAmenitiesAsync(GetAmenitiesQuery query)
        {
            ArgumentNullException.ThrowIfNull(query, nameof(query));

            var amenities = _context.Amenities.AsQueryable();

            if (query.IncludeCategory.HasValue && query.IncludeCategory.Value)
                amenities = amenities.Include(a => a.AmenityCategory);

            if (query.IncludeRoom.HasValue && query.IncludeRoom.Value)
                amenities = amenities.Include(a => a.ConferenceRoom);

            if (query.ConferenceRoomId.HasValue)
                amenities = amenities.Where(a => a.ConferenceRoomId == query.ConferenceRoomId);

            return await amenities
                .OrderBy(a => a.Name)
                .ToListAsync();
        }

        public Task<Amenity> GetAmenityAsync(GetAmenityQuery query)
        {
            ArgumentNullException.ThrowIfNull(query, nameof(query));

            var queryable = _context.Amenities.AsQueryable();

            if (query.IncludeCategory.HasValue && query.IncludeCategory.Value)
                queryable = queryable.Include(a => a.AmenityCategory);

            if(query.IncludeConferenceRoom.HasValue && query.IncludeConferenceRoom.Value)
                queryable = queryable.Include(a => a.ConferenceRoom);


#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            return queryable
                .FirstOrDefaultAsync(a => a.AmenityId == query.AmenityId);
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
        }

 
    }
}
