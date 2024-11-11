using AutoMapper;
using Blazored.LocalStorage;
using BookingSystem.Shared.Components.Pages.Dashboard;
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
    public class AnalyticsDataService:DataServiceBase, IAnalyticsDataService
    {
        private readonly IMapper _mapper;
        public AnalyticsDataService(IClient client, ILocalStorageService localStorageService, 
            NavigationManager navigationManager, IMapper mapper) : base(client, localStorageService, navigationManager)
        {
            _mapper = mapper;
        }
       

        public async Task<ConferenceRoomChangeEventListViewModel> GetConferenceRoomChangeEventListViewModel(Guid? conferenceRoomId, string? changeEventType,bool? includeRoom ,int? pageNumber, int? pageSize)
        {
            var changeEventListVm = await _client.GetConferenceRoomChangeEventsAsync(conferenceRoomId, changeEventType,includeRoom,pageNumber,pageSize);
            return _mapper.Map<ConferenceRoomChangeEventListViewModel>(changeEventListVm);
        }
    }
}
