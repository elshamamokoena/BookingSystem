using BookingSystem.Application.Features.Amenities.Queries.GetAmenities;
using BookingSystem.Application.Features.Amenities.Queries.GetAmenity;
using BookingSystem.Domain.Entities.Amenities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Contracts.Persistence
{
    public interface IAmenityRepository:IAsyncRepository<Amenity>
    {

        Task<Amenity> GetAmenityAsync(GetAmenityQuery query);
        Task<IEnumerable<Amenity>> GetAmenitiesAsync(GetAmenitiesQuery query);
        //Task<AmenityCategory> AddMenityCategory(AmenityCategory amenityCategory);
        //void DeleteAmenityCategory(AmenityCategory amenityCategory);
        //void UpdateAmenityCategory(AmenityCategory amenityCategory);
        //Task<AmenityCategory> GetAmenityCategoryAsync(Guid amenityCategoryId);
        //Task<IEnumerable<AmenityCategory>> GetAmenityCategoriesAsync();
        //Task<bool> AmenityCategoryExists(Guid amenityCategoryId);

        //Task<bool> SaveChangesAsync();

        //Task<Amenity> AddAmenity(Amenity amenity);
        //void DeleteAmenity(Amenity amenity);
        //void UpdateAmenity(Amenity amenity);
        //Task<Amenity> GetAmenityForCategoryAsync(Guid CategoryId, Guid amenityId);
        //Task<IEnumerable<Amenity>> GetAmenitiesForRoomAsync(Guid conferenceRoomId);
        //Task<IEnumerable<Amenity>> GetAmenitiesForRoomAsync(Guid conferenceRoomId, Guid categoryId);
        //Task<IEnumerable<Amenity>> GetAmenitiesAsync();
        //Task<IEnumerable<Amenity>> GetAmenitiesForCategoryAsync(Guid categoryId);
        //Task<Amenity> GetAmenityAsync(Guid amenityId);
        //Task<bool> AmenityExistsAsync(Guid amenityId);

    }
}
