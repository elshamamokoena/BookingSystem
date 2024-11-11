using AutoMapper;
using Blazored.LocalStorage;
using BookingSystem.Shared.Components.Pages.ConferenceRooms;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Services.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Services
{
    public class AmenityDataService :DataServiceBase, IAmenityDataService
    {
        private readonly IMapper _mapper;
        public AmenityDataService(IClient client, ILocalStorageService localStorageService, 
            NavigationManager navigationManager, IMapper mapper) : base(client, localStorageService, navigationManager)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> CreateAmenityAsync(AmenityViewModel amenity)
        {
            try
            {
                CreateAmenityCommand command = _mapper.Map<CreateAmenityCommand>(amenity);
                var newId = await _client.CreateAmenityAsync(command);
                return new ApiResponse<Guid> { Data= newId,  IsSuccess = true, Message = "Amenity added successfully" };
            }
            catch(ApiException<Guid> ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ApiResponse<Guid>> DeleteAmenityAsync(Guid amenity)
        {
            try
            {
                await _client.DeleteAmenityAsync(amenity);
                return new ApiResponse<Guid> { IsSuccess = true, Message = "Amenity deleted successfully" };
            }
            catch (ApiException<Guid> ex)
            {
                return ConvertApiExceptions<Guid>(ex);

            }
            
        }

        public async Task<IEnumerable<AmenityViewModel>> GetAmenitiesAsync(Guid? roomId, bool? includeCategory, bool? includeRoom)
        {
            var amenities = await _client.GetAmenitiesAsync(roomId, includeCategory, includeRoom);
            return _mapper.Map<IEnumerable<AmenityViewModel>>(amenities);
        }

        public async Task<AmenityViewModel> GetAmenityAsync(Guid amenityId, bool? includeCategory, bool? includeRoom)
        {
            var amenity = await _client.GetAmenityAsync(amenityId,includeCategory,includeRoom);
            return _mapper.Map<AmenityViewModel>(amenity);
        }

        public async Task<IEnumerable<AmenityCategoryViewModel>> GetAmenityCategoriesAsync()
        {
            var categories = await _client.GetAmenityCategoriesAsync();
            return  _mapper.Map<IEnumerable<AmenityCategoryViewModel>>(categories);
        }

        public async Task<ApiResponse<Guid>> UpdateAmenityAsync(AmenityViewModel amenity)
        {
            try
            {
                UpdateAmenityCommand command = _mapper.Map<UpdateAmenityCommand>(amenity);
                await _client.UpdateAmenityAsync(command);
                return new ApiResponse<Guid> { IsSuccess = true, Message="Amenity was updated successfully"};
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }

        }
    }
}
