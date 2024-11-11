using BookingSystem.Shared.Components.Pages.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Contracts
{
    public interface IAnalyticsDataService
    {
        Task<ConferenceRoomChangeEventListViewModel> GetConferenceRoomChangeEventListViewModel(Guid? conferenceRoomId, string? changeEventType,bool? includeRoom, int? pageNumber,int ? pageSize);
    }
}
