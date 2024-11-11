using AutoMapper;
using BookingSystem.Application.Features.Amenities.Queries.GetAmenity;
using BookingSystem.Application.Features.ConferenceRooms.Commands.CreateConferenceRoom;
using BookingSystem.Application.Features.ConferenceRooms.Commands.UpdateConferenceRoom.UpdateConferenceRoom;
using BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRoom;
using BookingSystem.Application.Features.ConferenceRooms.Queries.GetConferenceRooms;
using BookingSystem.Application.Features.RoomBookingEvents.Queries.GetRoomBookingEvents;
using BookingSystem.Application.Helpers;
using BookingSystem.ClassLibrary;
using BookingSystem.Domain.Entities.ConferenceRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Profiles
{
    public class ConferenceRoomProfile:Profile
    {
        public ConferenceRoomProfile()
        {
            CreateMap<CreateConferenceRoomCommand, ConferenceRoom>();
            CreateMap<ConferenceRoom, ConferenceRoomListDto>();
            CreateMap<ConferenceRoom, ConferenceRoomVm>();
            CreateMap<UpdateConferenceRoomCommand, ConferenceRoom>();
            CreateMap<ConferenceRoom, ConferenceRoomDto>();
            CreateMap<ConferenceRoom, ConferenceRoomForChangeEventDto>();
        }
    }
}
