using BookingSystem.Shared.Components.Pages.ConferenceRooms;
using BookingSystem.Shared.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Contracts
{
    public interface IAmenityDataService
    {
        Task<AmenityViewModel> GetAmenityAsync(Guid amenityId, bool? includeCategory, bool? includeRoom);
        Task<ApiResponse<Guid>> UpdateAmenityAsync(AmenityViewModel amenity);
        Task<ApiResponse<Guid>> CreateAmenityAsync(AmenityViewModel amenity);
        Task<IEnumerable<AmenityCategoryViewModel>> GetAmenityCategoriesAsync();
        Task<IEnumerable<AmenityViewModel>> GetAmenitiesAsync(Guid? roomId, bool? includeCategory, bool? includeRoom);
        Task<ApiResponse<Guid>> DeleteAmenityAsync(Guid amenity);
    }
}
