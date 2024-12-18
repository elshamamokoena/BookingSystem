﻿using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRoom;
using BookingSystem.Application.Helpers;
using BookingSystem.ClassLibrary;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRooms
{
    public class GetConferenceRoomsQueryHandler : IRequestHandler<GetConferenceRoomsQuery, ConferenceRoomListVm>
    {
        private readonly IConferenceRoomRepository _conferenceRoomRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        public GetConferenceRoomsQueryHandler(IConferenceRoomRepository conferenceRoomRepository,
            IBookingRepository bookingRepository,
            IMapper mapper)
        {
            _conferenceRoomRepository = conferenceRoomRepository;
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<ConferenceRoomListVm> Handle(GetConferenceRoomsQuery request, CancellationToken cancellationToken)
        {
            //// You should be able to get resources without any parameters provided
            var pagedRooms = await _conferenceRoomRepository.GetConferenceRoomsAsync(request);

            var count = pagedRooms.TotalCount;
            var rooms = _mapper.Map<List<ConferenceRoomListDto>>(pagedRooms);
            var listToReturn = new ConferenceRoomListVm()
            { ConferenceRooms = rooms, Count = count, PageNumber = request.PageNumber, PageSize = request.PageSize };

            if (request.StartTime == null || request.EndTime == null)
            {
                return listToReturn;
            }
            foreach (var room in rooms)
            {
                room.IsAvailable = await _conferenceRoomRepository
                    .IsAvableForBooking(request.StartTime.Value, request.EndTime.Value, room.ConferenceRoomId);
            }
            listToReturn.ConferenceRooms = rooms;
            return listToReturn;
        }
    }

}
