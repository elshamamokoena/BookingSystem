using AutoMapper;
using Blazored.LocalStorage;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Models.Rooms;
using BookingSystem.Shared.Services;
using BookingSystem.Shared.Services.Base;

namespace BookingSystem.Shared.Services
{
    public class ConferenceRoomService :DataServiceBase, IConferenceRoomService
    {
        private readonly IMapper _mapper;
        public ConferenceRoomService(IMapper mapper, IClient client, ILocalStorageService localStorage)
            :base(client,localStorage)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomViewModel>> GetConferenceRooms(string? searchQuery, DateTime? start, DateTime? end, int? pageNumber, int? pageSize)
        {
            var rooms = await _client.GetConferenceRoomsAsync(searchQuery, start, end, pageNumber, pageSize);
            return _mapper.Map<IEnumerable<RoomViewModel>>(rooms);
        }
    }
}
