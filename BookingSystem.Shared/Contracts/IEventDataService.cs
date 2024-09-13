using BookingSystem.Shared.Models.Events;
using BookingSystem.Shared.Services;
using BookingSystem.Shared.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Contracts
{
    public interface IEventDataService
    {
        public Task<ApiResponse<EventViewModel>> CreateEventAsync(EventViewModel @event);
        public Task<IEnumerable<EventViewModel>> GetEventsAsync(DateTime ?startTime, DateTime? endTime,int? pageNumber, int? pageSize);
        public Task<EventViewModel> GetEventAsync(Guid eventId);
        public Task UpdateEventAsync(EventViewModel @event);
    }
}
