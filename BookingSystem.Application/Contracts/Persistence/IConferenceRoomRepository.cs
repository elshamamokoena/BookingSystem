﻿using BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRoom;
using BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRooms;
using BookingSystem.Application.ResourceParameters;
using BookingSystem.ClassLibrary;
using BookingSystem.Domain.Entities.ConferenceRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Contracts.Persistence
{
    public interface IConferenceRoomRepository:IAsyncRepository<ConferenceRoom>
    {
        // 1. Room and Amenity Management (Office Manager)

        // 1.1 Office Manager can create a new conference room

        // 1.2 Office Manager can update an existing conference room
        void UpdateConferenceRoom(ConferenceRoom conferenceRoom);

        // 1.3 Office Manager can delete an existing conference room

        // View all conference rooms
        // Resource parameters are used to filter, sort, search and/or page data in the database.
        Task<PagedList<ConferenceRoom>> GetConferenceRoomsAsync(GetConferenceRoomsQuery query);

        //Task<PagedList<ConferenceRoom>> GetConferenceRoomsAsync( string? searchQuery, DateTime? startTime, DateTime? endTime, int pageNumber,int pageSize);
        //  Task<IEnumerable<ConferenceRoom>> GetAvailableConferenceRoomsAsync(DateTime startTime, DateTime endTime);
        Task<ConferenceRoom> GetConferenceRoomAsync(GetConferenceRoomQuery query);
        Task<int> GetConferenceRoomsCountAsync();
        Task<bool> IsAvableForBooking(DateTime starttime, DateTime endTime , Guid roomId);


    }
}
