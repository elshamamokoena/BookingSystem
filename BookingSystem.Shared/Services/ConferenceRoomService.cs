using AutoMapper;
using Blazored.LocalStorage;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Models.Rooms;
using BookingSystem.Shared.Services;
using BookingSystem.Shared.Services.Base;
using Microsoft.AspNetCore.Components;

namespace BookingSystem.Shared.Services
{
    public class ConferenceRoomService :DataServiceBase, IConferenceRoomService
    {
        private readonly IMapper _mapper;
        public ConferenceRoomService(IMapper mapper, IClient client, ILocalStorageService localStorage, 
            NavigationManager navigationManager)
            :base(client,localStorage, navigationManager)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> CreateConferenceRoomAsync(RoomViewModel room)
        {
            try
            {
                var command = _mapper.Map<CreateConferenceRoomCommand>(room);
                var newId = await _client.CreateConferenceRoomAsync(command);
                return new ApiResponse<Guid> { Data = newId , IsSuccess=true , Message="Room added successfully" };
            }
            catch(ApiException<Guid> ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
        public async Task<ApiResponse<Guid>> DeleteConferenceRoomAsync(Guid roomId)
        {
            try
            {
                await _client.DeleteConferenceRoomAsync(roomId);
                return new ApiResponse<Guid> (){ IsSuccess = true };

            }catch(ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
        public async Task<RoomViewModel> GetConferenceRoomAsync(Guid roomId, bool? includeBookings, bool? includeAmenities)
        {
            var room = await _client.GetConferenceRoomAsync(roomId, includeAmenities,includeBookings);
            return _mapper.Map<RoomViewModel>(room);
        }
        public async Task<ConferenceRoomListViewModel> GetConferenceRoomsAsync(string? searchQuery, DateTime? start, DateTime? end, int? pageNumber, int? pageSize)
        {
            var rooms = await _client.GetConferenceRoomsAsync(searchQuery, start, end, pageNumber, pageSize);
            
            return _mapper.Map<ConferenceRoomListViewModel>(rooms);
        }
        public async Task<ApiResponse<Guid>> UpdateConferenceRoomAsync(RoomViewModel room)
        {
            try
            {
                UpdateConferenceRoomCommand command = _mapper.Map<UpdateConferenceRoomCommand>(room);
                await _client.UpdateConferenceRoomAsync(command);
                return new ApiResponse<Guid> {IsSuccess = true, Message = "Room updated successfully" };
            }
            catch(ApiException<Guid> ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
