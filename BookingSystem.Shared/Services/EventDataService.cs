using AutoMapper;
using Blazored.LocalStorage;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Models.Events;
using BookingSystem.Shared.Services;
using BookingSystem.Shared.Services.Base;

namespace BookingSystem.Shared.Services
{
    public class EventDataService :DataServiceBase, IEventDataService
    {
        private readonly IMapper _mapper;

        public EventDataService(IMapper mapper, IClient client, ILocalStorageService localStorage)
            :base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<EventViewModel>> CreateEventAsync(EventViewModel @event)
        {
            var response = await _client.CreateEventAsync(_mapper.Map<CreateEventCommand>(@event));
            if (!response.Success)
            {
                return new ApiResponse<EventViewModel>
                {
                    Data = null,
                    IsSuccess = response.Success,
                    Message = response.Message
                };
            }else
            {
                return new ApiResponse<EventViewModel>
                {
                    Data = _mapper.Map<EventViewModel>(response.Event),
                    IsSuccess = response.Success,
                    Message = response.Message
                };
            }
         
        }

        public async Task<EventViewModel> GetEventAsync(Guid eventid)
        {
            var @event = await _client.GetEventAsync(eventid);
            var eventToRet=  _mapper.Map<EventViewModel>(@event);
            return eventToRet;
        }

        public async Task<IEnumerable<EventViewModel>> GetEventsAsync(DateTime? startTime, DateTime? endTime,int ? pageNumber, int ? pageSize)
        {
            var bookings = await _client.GetEventsAsync(startTime, endTime,pageNumber,pageSize);
            return _mapper.Map<IEnumerable<EventViewModel>>(bookings);
        }

        public async Task UpdateEventAsync(EventViewModel @event)
        {
            await _client.UpdateEventAsync(_mapper.Map<UpdateEventCommand>(@event));
        }
    }
}
