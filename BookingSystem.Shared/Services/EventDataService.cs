using AutoMapper;
using Blazored.LocalStorage;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Models.Events;
using BookingSystem.Shared.Services;
using BookingSystem.Shared.Services.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BookingSystem.Shared.Services
{
    public class EventDataService :DataServiceBase, IEventDataService
    {
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public EventDataService(IMapper mapper, NavigationManager navigationManager 
            ,IClient client, ILocalStorageService localStorage,
            AuthenticationStateProvider authenticationStateProvider, IAuthorizationService authorizationService)
            :base(client, localStorage, navigationManager)
        {
            _mapper = mapper;
            _authorizationService = authorizationService;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<ApiResponse<Guid>> CreateEventAsync(EventViewModel @event)
        {
            try
            {
                var command = _mapper.Map<CreateEventCommand>(@event);
                var newId = await _client.CreateEventAsync(command);
                return new ApiResponse<Guid> { Data = newId };

            }
            catch(ApiException<Guid> ex)
            {
                return ConvertApiExceptions<Guid>(ex);
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

            try
            {
                var bookings = await _client.GetEventsAsync(startTime, endTime, pageNumber, pageSize);
                return _mapper.Map<IEnumerable<EventViewModel>>(bookings);
            }catch (ApiException ex)
            {
                var response = ConvertApiExceptions<Guid>(ex);
                //Use response if needed
                return [];
            }


        }

        public async Task UpdateEventAsync(EventViewModel @event)
        {
            await _client.UpdateEventAsync(_mapper.Map<UpdateEventCommand>(@event));
        }
    }
}
