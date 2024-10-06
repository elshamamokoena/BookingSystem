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
                return new ApiResponse<Guid> { Data = newId };
            }
            catch(ApiException<Guid> ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }



        public async Task<IEnumerable<RoomViewModel>> GetConferenceRooms(string? searchQuery, DateTime? start, DateTime? end, int? pageNumber, int? pageSize)
        {
            var rooms = await _client.GetConferenceRoomsAsync(searchQuery, start, end, pageNumber, pageSize);
            return _mapper.Map<IEnumerable<RoomViewModel>>(rooms);
        }
    }
}
