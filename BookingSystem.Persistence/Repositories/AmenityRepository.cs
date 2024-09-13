using BookingSystem.Application.Contracts.Persistence;
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
    public class AmenityRepository : IAmenityRepository
    {
        private readonly BookingSystemDbContext _context;
        public AmenityRepository(BookingSystemDbContext context)
        {
            _context = context;
        }
        public async Task<Amenity> AddAmenity(Amenity amenity)
        {
            await _context.Amenities.AddAsync(amenity);
            
            return amenity;
        }

        public async Task<AmenityCategory> AddMenityCategory(AmenityCategory amenityCategory)
        {
            await _context.AmenityCategories.AddAsync(amenityCategory);
            return amenityCategory;

        }

        public Task<bool> AmenityCategoryExists(Guid amenityCategoryId)
        {
            return _context
                .AmenityCategories.AnyAsync(ac => ac.AmenityCategoryId == amenityCategoryId);
        }

        public Task<bool> AmenityExistsAsync(Guid amenityId)
        {
            return _context
                .Amenities.AnyAsync(a => a.AmenityId == amenityId);
        }

        public void DeleteAmenity(Amenity amenity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAmenityCategory(AmenityCategory amenityCategory)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Amenity>> GetAmenitiesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Amenity>> GetAmenitiesForCategoryAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Amenity>> GetAmenitiesForRoomAsync(Guid conferenceRoomId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Amenity>> GetAmenitiesForRoomAsync(Guid conferenceRoomId, Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<Amenity> GetAmenityAsync(Guid amenityId)
        {
            if (amenityId == Guid.Empty) throw new ArgumentNullException(nameof(amenityId));
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            return _context.Amenities
                .FirstOrDefaultAsync(a => a.AmenityId == amenityId);
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
        }

        public Task<IEnumerable<AmenityCategory>> GetAmenityCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AmenityCategory> GetAmenityCategoryAsync(Guid amenityCategoryId)
        {
            if (amenityCategoryId == Guid.Empty) throw new ArgumentNullException(nameof(amenityCategoryId));

#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            return _context.AmenityCategories
                .FirstOrDefaultAsync(ac => ac.AmenityCategoryId == amenityCategoryId);
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
        }

        public Task<Amenity> GetAmenityForCategoryAsync(Guid CategoryId, Guid amenityId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateAmenity(Amenity amenity)
        {
            _context.Amenities.Update(amenity);
        }

        public void UpdateAmenityCategory(AmenityCategory amenityCategory)
        {
            throw new NotImplementedException();
        }
    }
}
