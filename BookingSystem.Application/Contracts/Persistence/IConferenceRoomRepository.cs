using BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRooms;
using BookingSystem.Application.ResourceParameters;
using BookingSystem.Domain.Entities.ConferenceRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Contracts.Persistence
{
    public interface IConferenceRoomRepository
    {
        // 1. Room and Amenity Management (Office Manager)

        // 1.1 Office Manager can create a new conference room
        Task<ConferenceRoom> AddConferenceRoom(ConferenceRoom conferenceRoom);

        // 1.2 Office Manager can update an existing conference room
        void UpdateConferenceRoom(ConferenceRoom conferenceRoom);

        // 1.3 Office Manager can delete an existing conference room
        void DeleteConferenceRoom(ConferenceRoom conferenceRoom);

        // View all conference rooms
        // Resource parameters are used to filter, sort, search and/or page data in the database.
        Task<IEnumerable<ConferenceRoom>> GetConferenceRoomsAsync(GetConferenceRoomsQuery resourceParameters);
      //  Task<IEnumerable<ConferenceRoom>> GetAvailableConferenceRoomsAsync(DateTime startTime, DateTime endTime);

        Task<int> GetConferenceRoomsCountAsync();
        Task<ConferenceRoom> GetConferenceRoomAsync(Guid conferenceRoomId);
        Task<bool> ConferenceRoomExistsAsync(Guid conferenceRoomId);
        Task<bool> SaveChangesAsync();
    }
}
