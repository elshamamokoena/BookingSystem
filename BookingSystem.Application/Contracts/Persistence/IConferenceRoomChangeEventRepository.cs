using BookingSystem.Application.Features.RoomBookingEvents.Queries.GetRoomBookingEvents;
using BookingSystem.Application.Helpers;
using BookingSystem.ClassLibrary;
using BookingSystem.Domain.Entities.RoomBookingEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Contracts.Persistence
{
    public interface IConferenceRoomChangeEventRepository : IAsyncRepository<ConferenceRoomChangeEvent>
    {
        Task<ConferenceRoomChangeEvent> AddOrUpdateRoomBookingEventAsync(Guid conferenceRoomId);
        Task<PagedList<ConferenceRoomChangeEvent>> GetConferenceRoomChangeEventsAsync(GetConferenceRoomChangeEventsQuery query);
    }
}
